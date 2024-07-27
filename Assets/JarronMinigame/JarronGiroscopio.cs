using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using Debug = UnityEngine.Debug;

public class JarronGiroscopio : MonoBehaviour
{
    Gyroscope gyro;

    [SerializeField] private float threshold = 10;
    [SerializeField] private float torque = 10;
    Rigidbody2D rb;
    [SerializeField] private JarronAscenso jarronAscenso;

    [SerializeField] GameObject join;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    private void Update()
    {
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

    public void JarronFall()
    {
        join.SetActive(false);
    }
}
