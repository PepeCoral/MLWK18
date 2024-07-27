using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    Gyroscope gyro;
    public bool isShaking = false;

    CastigoHumo castigoHumo;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;

        castigoHumo = GetComponent<CastigoHumo>();
    }

    private void Update()
    {
        //isShaking = DetectShaking();

        castigoHumo.blow = isShaking;
    }

    private bool DetectShaking()
    {
        return gyro.userAcceleration.magnitude > 0.7f;
    }
}
