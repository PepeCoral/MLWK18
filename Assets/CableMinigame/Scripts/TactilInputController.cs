using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TactilInputController : MonoBehaviour
{
	[SerializeField] private LayerMask GrapableLayerMask;
	[SerializeField] private MinigameManager MinigameManager;
	
	private InputManager InputMan;
	private ITactilGameObject GrappedObject;
	
	// Use this for initialization
	void Awake () {
		InputMan = GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!MinigameManager.IsMinigameActive())
		{
			DeAttach();
			return;
		}
		
		if (InputMan.TouchPressedThisFrame)
		{
			TryGetObject();
		}

		if (InputMan.TouchReleasedThisFrame && GrappedObject != null)
		{
			DeAttach();
		}


	}

	public void DeAttach()
	{
		if (GrappedObject != null)
		{
			GrappedObject.OnReleased();
			GrappedObject = null;
		}
	}

	private void TryGetObject()
	{
		Vector3 WorldPoint = InputMan.TouchLocationFromLowerCam;
		
		Collider2D[] cols = Physics2D.OverlapPointAll(WorldPoint, GrapableLayerMask);

		foreach (Collider2D col in cols)
		{
			if (col)
			{
				ITactilGameObject TempGrappedObject = col.gameObject.GetComponent<ITactilGameObject>();

				if (TempGrappedObject != null && TempGrappedObject.CanBeSelected())
				{
					GrappedObject = TempGrappedObject;
					GrappedObject.OnPressed(InputMan, this);
					break;
				}
			}
		}
	}
}
