using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Lever : MonoBehaviour, IGrapeable
{
	private InputManager InputMan;
	private InputController InputCtrl;
	private bool isCompleted = false;


	[SerializeField] private CableMinigameManager CablesManager;
	
	//If the touch X gets away further than this, the inputgrab gets canceled
	[SerializeField] private float maxXArea = 30;
	//The player needs to move the lever this distance to trigger the lever
	[SerializeField] private float YTarget = 200;
	
	// Update is called once per frame
	void Update () {
		if (InputMan && InputCtrl)
		{
			if (Mathf.Abs(InputMan.TouchLocationFromLowerCam.x - transform.position.x) > maxXArea)
			{
				InputCtrl.DeAttach();
			}else

			if (-InputMan.TouchLocationFromLowerCam.y + transform.position.y > YTarget)
			{
				if (CablesManager.CanGameEnd())
				{
					isCompleted = true;
					CablesManager.GameCompleted();
					InputCtrl.DeAttach();
				}

			}
		}
	}

	public void OnPressed(InputManager InputManager, InputController NewInputCtrl)
	{
		InputMan = InputManager;
		InputCtrl = NewInputCtrl;
	}

	public void OnReleased()
	{
		if (isCompleted)
		{
			//CHECK END CONDITIONS
			transform.position = transform.position + Vector3.down * YTarget;
		}

		InputMan = null;
		InputCtrl = null;
	}

	public bool CanBeGrapped()
	{
		return !isCompleted;
	}
}
