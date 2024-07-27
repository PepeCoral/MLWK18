using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightBulb : MonoBehaviour
{
	
	[SerializeField] private Image ImageToEdit;
	[SerializeField] private bool StartsOn = false;
	private void Awake()
	{
		if (StartsOn)
		{
			TurnOn();
		}
		else
		{
			TurnOff();
		}
	}

	public void TurnOn()
	{
		ImageToEdit.enabled = true;
	}

	public void TurnOff()
	{
		ImageToEdit.enabled = false;
	}
}
