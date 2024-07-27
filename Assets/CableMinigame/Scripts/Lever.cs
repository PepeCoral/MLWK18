using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Lever : MonoBehaviour, ITactilGameObject
{
	private InputManager InputMan;
	private TactilInputController _tactilInputCtrl;
	private bool isDownMovementCompleted = false;
	private Vector3 StartLocation;

	[SerializeField] private MinigameManager MinigameManager;

	//If the touch X gets away further than this, the inputgrab gets canceled
	[SerializeField] private float maxXArea = 30;

	//The player needs to move the lever this distance to trigger the lever
	[SerializeField] private float YTarget = 200;
	[SerializeField] private LightBulb lightBulb;
	// Update is called once per frame


	private void Awake()
	{
		StartLocation = transform.position;
	}

	void Update()
	{
		if (InputMan && _tactilInputCtrl)
		{
			if (Mathf.Abs(InputMan.TouchLocationFromLowerCam.x - transform.position.x) > maxXArea)
			{
				_tactilInputCtrl.DeAttach();
			}
			else if (Mathf.Abs(transform.position.y - StartLocation.y) > YTarget)
			{
				isDownMovementCompleted = true;
				_tactilInputCtrl.DeAttach();
			}
			else
			{
				if (InputMan.TouchLocationFromLowerCam.y >= transform.position.y)
				{
					return;
				}
				else
				{
					Vector3 NewLocation = new Vector3(transform.position.x, InputMan.TouchLocationFromLowerCam.y, InputMan.TouchLocationFromLowerCam.z);
					transform.position = NewLocation;
				}
			}
		}
	}

	public void OnPressed(InputManager InputManager, TactilInputController newTactilInputCtrl)
	{
		InputMan = InputManager;
		_tactilInputCtrl = newTactilInputCtrl;
	}

	public void OnReleased()
	{
		InputMan = null;
		_tactilInputCtrl = null;
		
		if (isDownMovementCompleted)
		{
			if (MinigameManager.CanMinigameEnd())
			{
				lightBulb.TurnOn();
				MinigameManager.CompleteMinigame();
			}
			else
			{
				StartCoroutine(FailedToTurnOn());
			}
		}
		else
		{
			transform.position = StartLocation;
		}
	}

	public bool CanBeSelected()
	{
		return !isDownMovementCompleted;
	}

	IEnumerator FailedToTurnOn()
	{
		lightBulb.TurnOn();

		yield return new WaitForSeconds(0.25f);

		lightBulb.TurnOff();

		isDownMovementCompleted = false;
		transform.position = StartLocation;
		
		yield return null;
	}
}
