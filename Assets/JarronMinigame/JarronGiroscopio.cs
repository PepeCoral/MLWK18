using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using DG.Tweening;

public class JarronGiroscopio : MonoBehaviour
{
    Gyroscope gyro;

    [SerializeField] private float threshold = 10;
    [SerializeField] private float torque = 10;
    Rigidbody2D rb;
    [SerializeField] private JarronAscenso jarronAscenso;
    [SerializeField] private JarronMinigameManager manager;
    [SerializeField] GameObject join;
    [SerializeField] private float gravityScale;
    [SerializeField] private AudioSource _audio;

    [SerializeField] private Vector3 finalRotation;

    [SerializeField] private Vector3 leftSide;
    [SerializeField] private Vector3 rightSide;
    private bool falling = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    private void Update()
    {
        if (falling) return;
        var input = GetInputGyro();

        if (input == 1)
        {
            rb.AddTorque(torque, ForceMode2D.Force);
        }
        else if (input == -1)
        {
            rb.AddTorque(-torque, ForceMode2D.Force);
        }

        if (rb.gameObject.transform.rotation.eulerAngles.z > 90 && rb.gameObject.transform.rotation.eulerAngles.z < 270)
        {
            JarronFall();
        }


    }

    private int GetInputGyro()
    {
        float yRotation = gyro.attitude.eulerAngles.y;

        var rotation2 = GamePad.CirclePad.y;

        if (rotation2 > 0.5f)
            return 1;
        if (rotation2 < -0.5f)
            return -1;

#if UNITY_EDITOR
        return (int)Input.GetAxisRaw("Horizontal");
#endif

        yRotation %= 360;

        if (yRotation > threshold && yRotation < 180)
            return 1;
        if (yRotation < 360 - threshold && yRotation > 180)
            return -1;
        return 0;
    }

    public void CompleteMinigame()
    {

    }

    public void StartMinigame()
    {
        rb.gravityScale = gravityScale;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    public void JarronFall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        falling = true;
        join.SetActive(false);
    }

    public void FallCorrect()
    {
        rb.bodyType = RigidbodyType2D.Static;
        falling = true;


        Sequence sec = DOTween.Sequence();
        sec.Append(transform.DORotate(finalRotation, 1));
        sec.AppendInterval(1);
        sec.Append(transform.DORotate(leftSide, 0.3f).SetEase(Ease.InOutExpo));
        sec.Append(transform.DORotate(rightSide, 0.4f).SetEase(Ease.Linear));
        sec.Append(transform.DORotate(leftSide, 0.4f).SetEase(Ease.Linear));
        sec.Append(transform.DORotate(rightSide, 0.4f).SetEase(Ease.Linear));
        sec.Append(transform.DORotate(leftSide, 0.4f).SetEase(Ease.Linear));
        sec.AppendCallback(() => { JarronFall(); });

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        manager.CompleteMinigame();
        _audio.Play();


    }
}
