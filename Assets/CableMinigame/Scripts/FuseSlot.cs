using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseSlot : MonoBehaviour
{
	public bool isSlotted { get; private set; }
	
	[SerializeField] private LightBulb SlotBulb;

	public void SetIsSlotted(bool newIsSlotted, bool isBroken)
	{
		isSlotted = newIsSlotted;

		if (!isBroken && isSlotted)
		{
			SlotBulb.TurnOn();
		}
		else
		{
			SlotBulb.TurnOff();
		}
	}
}
