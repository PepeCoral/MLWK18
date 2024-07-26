using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverExtintor : MonoBehaviour
{

	// Use this for initialization

	public GameObject input;

	private Vector2 position;
	private InputManager inputManager;
	[SerializeField] private float speedMove = 20f;

	public Camera UpperCamera;
	private void Awake()
	{
		inputManager = input.GetComponent<InputManager>();
	}
	void Start()
	{
		position = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		position = inputManager.GetPosition();
		Debug.Log("Mirilla" + position.x + " " + position.y);
		var step = speedMove * Time.deltaTime; // calculate distance to move
		Vector3 newPosition;
		if (position.x > 0 || position.y > 0)
		{

			newPosition = UpperCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, 0));

		}
		else
		{

			newPosition = UpperCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));


		}


		transform.position = Vector3.MoveTowards(transform.position, new Vector3(newPosition.x, newPosition.y, 0), step);
	}

}

