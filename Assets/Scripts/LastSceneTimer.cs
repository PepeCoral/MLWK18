﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneTimer : MonoBehaviour
{

	[SerializeField] private float TimeToEndGame = 10;

	private float CurrentTimeToEndGame;
	// Use this for initialization
	void Awake ()
	{
		CurrentTimeToEndGame = TimeToEndGame;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTimeToEndGame -= Time.deltaTime;

		if (CurrentTimeToEndGame <= 0)
		{
			CurrentTimeToEndGame = 0;
			SceneSwitcher.Instance.SwitchToNextScene();
		}
	}
}
