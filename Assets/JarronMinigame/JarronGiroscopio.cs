using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronGiroscopio : MonoBehaviour
{
    Gyroscope gyro;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    private void Update()
    {

        float yRotation = gyro.attitude.eulerAngles.y;

    }
}
