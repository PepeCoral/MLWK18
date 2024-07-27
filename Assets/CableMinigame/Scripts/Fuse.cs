using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour, ITactilGameObject
{
	[SerializeField] private bool isBroken = false;
	public bool isSlotted { get; private set; }
	
	[SerializeField] private FuseSlot AttachedFuseSlot;
	[SerializeField] private LayerMask FuseSlotLayer;
	private InputManager inputMan;
	// Use this for initialization
	void Awake ()
	{
		isSlotted = false;
		
		if (AttachedFuseSlot != null)
		{
			AttachedFuseSlot.isSlotted = true;
			isSlotted = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (inputMan)
		{
			transform.position = inputMan.TouchLocationFromLowerCam;
		}
	}

	public void OnPressed(InputManager InputManager, TactilInputController newTactilInputCtrl)
	{
		inputMan = InputManager;
	}

	public void OnReleased()
	{
		if (isBroken)
		{
			inputMan = null;
			
			if (AttachedFuseSlot)
			{
				AttachedFuseSlot.isSlotted = false;
				AttachedFuseSlot = null;
			}
			
			return;
		}
		
		if (!inputMan)
		{
			return;
		}
		
		Vector3 WorldPoint = inputMan.TouchLocationFromLowerCam;
		Collider2D[] cols = Physics2D.OverlapPointAll(WorldPoint, FuseSlotLayer);

		foreach (Collider2D col in cols)
		{
			if (col)
			{
				FuseSlot targetSlot = col.gameObject.GetComponent<FuseSlot>();

				if (targetSlot && !targetSlot.isSlotted)
				{
					targetSlot.isSlotted = true;
					AttachedFuseSlot = targetSlot;
					isSlotted = true;
					transform.position = new Vector3(AttachedFuseSlot.transform.position.x, AttachedFuseSlot.transform.position.y, AttachedFuseSlot.transform.position.z - 1);
					break;
				}
			}
		}
		
		inputMan = null;
		
	}

	public bool CanBeSelected()
	{
		return isBroken || !isSlotted;
	}
}
