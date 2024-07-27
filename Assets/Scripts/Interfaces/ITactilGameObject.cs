using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITactilGameObject
{
	void OnPressed(InputManager inputManager, TactilInputController tactilInputController);

	void OnReleased();

	bool CanBeSelected();
}