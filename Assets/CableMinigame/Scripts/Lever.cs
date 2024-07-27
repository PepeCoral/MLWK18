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
			else if (-InputMan.TouchLocationFromLowerCam.y + transform.position.y > YTarget)
			{
				isDownMovementCompleted = true;
				_tactilInputCtrl.DeAttach();
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


		if (isDownMovementCompleted)
		{
			//CHECK END CONDITIONS

			transform.position = transform.position + Vector3.down * YTarget;
		}

		InputMan = null;
		_tactilInputCtrl = null;
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
