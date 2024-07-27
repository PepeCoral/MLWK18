using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnTriggerOpenLevel : MonoBehaviour
{

	[SerializeField] private SceneSwitcher switcher;
	// Update is called once per frame
	void Update () {
		
	}

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			switcher.SwitchToNextScene();
		}
	}
}
