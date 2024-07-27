using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;

public class JarronGiroscopio : MonoBehaviour
{
    Gyroscope gyro;
    
    [SerializeField] private float threshold = 10;
    [SerializeField] private float torque = 10;
    Rigidbody2D rb;

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
            rb.AddTorque(torque);
        }
        else if (input == -1)
        {
            rb.AddTorque(-torque);
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

        if(yRotation > threshold && yRotation < 180)
            return 1;
        if (yRotation < 360 - threshold && yRotation > 180)
            return -1;
        return 0;
    }
}
