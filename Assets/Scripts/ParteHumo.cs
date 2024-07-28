using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteHumo : MonoBehaviour
{

	// Use this for initialization

	public Vector3 initPosition;
	public Vector3 endPosition;

	private void Awake()
	{
		transform.localPosition = endPosition;
	}

}
