﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CableColors {Yellow, Red, Green, Blue, Pink};
public class CableStartLocation : MonoBehaviour, ITactilGameObject {

	[SerializeField]
	CableColors cableColor;
	[SerializeField]
	LayerMask CableEndLocationMask;
	
	[SerializeField] private LightBulb lightBulb;
	
	private LineRenderer lineRen;
	private InputManager inputMan;

	public bool isCompleted { get; private set; }
	private void Awake()
	{
		isCompleted = false;
		
		lineRen = GetComponent<LineRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (inputMan)
		{
			lineRen.SetPosition(1, transform.InverseTransformPoint(inputMan.TouchLocationFromLowerCam));
		}
	}

	public void OnPressed(InputManager InputManager, TactilInputController newTactilInputCtrl)
	{
		inputMan = InputManager;
	}

	public void OnReleased()
	{
		if (!inputMan)
		{
			return;
		}
		
		Vector3 WorldPoint = inputMan.TouchLocationFromLowerCam;
		Collider2D[] cols = Physics2D.OverlapPointAll(WorldPoint, CableEndLocationMask);

		foreach (Collider2D col in cols)
		{
			if (col)
			{
				CableEndLocation EndLocationGO = col.gameObject.GetComponent<CableEndLocation>();

				if (EndLocationGO && EndLocationGO.CableEndColor == cableColor)
				{
					lineRen.SetPosition(1, transform.InverseTransformPoint(EndLocationGO.transform.position));
					isCompleted = true;
					lightBulb.TurnOn();
					break;
				}
			}
		}
		
		inputMan = null;

		if (!isCompleted)
		{
			lineRen.SetPosition(1, Vector3.zero);
		}
	}

	public bool CanBeSelected()
	{
		return !isCompleted && inputMan == null;
	}
}
