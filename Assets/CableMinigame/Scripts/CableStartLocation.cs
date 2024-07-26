using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CableColors {Yellow, Red, Green, Blue, Pink};
public class CableStartLocation : MonoBehaviour, IGrapeable {

	[SerializeField]
	CableColors cableColor;
	[SerializeField]
	LayerMask CableEndLocationMask;
	
	private LineRenderer lineRen;
	private InputManager inputMan;
	private bool isCompleted = false;
	private void Awake()
	{
		lineRen = GetComponent<LineRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (inputMan)
		{
			lineRen.SetPosition(1, transform.InverseTransformPoint(inputMan.TouchLocationFromLowerCam));
		}
	}

	public void OnPressed(InputManager InputManager)
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

				if (EndLocationGO && EndLocationGO.cableColor == cableColor)
				{
					lineRen.SetPosition(1, transform.InverseTransformPoint(EndLocationGO.transform.position));
					isCompleted = true;
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

	public bool CanBeGrapped()
	{
		return !isCompleted && inputMan == null;
	}
}
