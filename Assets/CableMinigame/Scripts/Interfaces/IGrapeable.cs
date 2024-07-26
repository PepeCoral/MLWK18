using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrapeable
{
	void OnPressed(InputManager InputManager, InputController InputCtrl);
	void OnReleased();

	bool CanBeGrapped();
}