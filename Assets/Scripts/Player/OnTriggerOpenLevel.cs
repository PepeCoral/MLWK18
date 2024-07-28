using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class OnTriggerOpenLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerMovement>().enabled = false;
			SceneSwitcher.Instance.SwitchToNextScene();
		}
	}
}
