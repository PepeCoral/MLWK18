using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private LayerMask GrapableLayerMask;
	[SerializeField] public Camera LowerCamera;
	
	private InputManager InputMan;

	private GameObject AttachedObject;
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
			GrappedObject.OnReleased();
			AttachedObject = null;
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
				GrappedObject = col.gameObject.GetComponent<IGrapeable>();

				if (GrappedObject.CanBeGrapped())
				{
					GrappedObject.OnPressed(InputMan);
					break;
				}
			}
		}
	}
}
