using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Lever : MonoBehaviour, ITactilGameObject
{
	private InputManager InputMan;
	private TactilInputController _tactilInputCtrl;
	private bool isCompleted = false;


	[SerializeField] private MinigameManager MinigameManager;
	
	//If the touch X gets away further than this, the inputgrab gets canceled
	[SerializeField] private float maxXArea = 30;
	//The player needs to move the lever this distance to trigger the lever
	[SerializeField] private float YTarget = 200;
	
	// Update is called once per frame
	void Update () {
		if (InputMan && _tactilInputCtrl)
		{
			if (Mathf.Abs(InputMan.TouchLocationFromLowerCam.x - transform.position.x) > maxXArea)
			{
				_tactilInputCtrl.DeAttach();
			}else

			if (-InputMan.TouchLocationFromLowerCam.y + transform.position.y > YTarget)
			{
				if (MinigameManager.CanMinigameEnd())
				{
					isCompleted = true;
					MinigameManager.CompleteMinigame();
					_tactilInputCtrl.DeAttach();
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
		if (isCompleted)
		{
			//CHECK END CONDITIONS
			transform.position = transform.position + Vector3.down * YTarget;
		}

		InputMan = null;
		_tactilInputCtrl = null;
	}

	public bool CanBeSelected()
	{
		return !isCompleted;
	}
}
