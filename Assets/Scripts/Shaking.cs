using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour {
	Gyroscope gyro = Input.gyro;
	public bool isShaking = false;

	private void Start()
	{
		Input.gyro.enabled = true;
	}

	private void Update()
	{
		isShaking = DetectShaking();
	}

	private bool DetectShaking()
	{
		return gyro.userAcceleration.magnitude > 1.5f;
	}
}
