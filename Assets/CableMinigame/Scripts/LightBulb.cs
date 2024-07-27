using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightBulb : MonoBehaviour
{

	[SerializeField] private Color OnColor;
	[SerializeField] private Color OffColour;
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
		ImageToEdit.color = OnColor;
	}

	public void TurnOff()
	{
		ImageToEdit.color = OffColour;
	}
}
