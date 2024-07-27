using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowActor : MonoBehaviour {

	[SerializeField] public GameObject targetToFollow;
	[Header("Camera limits")]
	[SerializeField] public float TopLimit;
	[SerializeField] public float BottomLimit;
	[SerializeField] public float LeftLimit;
	[SerializeField] public float RightLimit;
	
	private float Zoffset;
	// Use this for initialization
	void Awake () {
		Zoffset = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = new Vector3(targetToFollow.transform.position.x, targetToFollow.transform.position.y, Zoffset);

		if (targetPos.x < LeftLimit)
		{
			targetPos.x = LeftLimit;
		}else if (targetPos.x > RightLimit)
		{
			targetPos.x = RightLimit;
		}

		if (targetPos.y > TopLimit)
		{
			targetPos.y = TopLimit;
		}
		else if(targetPos.y < BottomLimit)
		{
			targetPos.y = BottomLimit;
		}

		transform.position = targetPos;
	}
}
