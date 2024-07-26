using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrapeable
{
	void OnPressed(InputManager InputManager);
	void OnReleased();

	bool CanBeGrapped();
}