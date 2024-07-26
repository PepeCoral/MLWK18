using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceDetector : MonoBehaviour {

	Gyroscope gyro;

	private void Start()
	{
		gyro = Input.gyro;
		gyro.enabled = true;
	}

	private void Update()
	{
		transform.rotation = gyro.attitude;
	}
}
