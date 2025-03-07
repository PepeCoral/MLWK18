﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneTimer : MonoBehaviour
{

	[SerializeField] private float TimeToEndGame = 10;

	private float CurrentTimeToEndGame;

	private bool timerEnabled = true;
	// Use this for initialization
	void Awake ()
	{
		CurrentTimeToEndGame = TimeToEndGame;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerEnabled)
		{
			CurrentTimeToEndGame -= Time.deltaTime;
			
			if (CurrentTimeToEndGame <= 0)
			{
				timerEnabled = false;
				CurrentTimeToEndGame = 0;
				SceneSwitcher.Instance.SwitchToNextScene();
			}
		}
	}
}
