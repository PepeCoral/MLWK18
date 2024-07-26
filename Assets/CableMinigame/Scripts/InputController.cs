using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private LayerMask GrapableLayerMask;
	
	private InputManager InputMan;
	private IGrapeable GrappedObject;
	
	// Use this for initialization
	void Awake () {
		InputMan = GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {

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
		GrappedObject.OnReleased();
		GrappedObject = null;
	}

	private void TryGetObject()
	{
		Vector3 WorldPoint = InputMan.TouchLocationFromLowerCam;
		
		Collider2D[] cols = Physics2D.OverlapPointAll(WorldPoint, GrapableLayerMask);

		foreach (Collider2D col in cols)
		{
			if (col)
			{
				IGrapeable TempGrappedObject = col.gameObject.GetComponent<IGrapeable>();

				if (TempGrappedObject.CanBeGrapped())
				{
					GrappedObject = TempGrappedObject;
					GrappedObject.OnPressed(InputMan, this);
					break;
				}
			}
		}
	}
}
