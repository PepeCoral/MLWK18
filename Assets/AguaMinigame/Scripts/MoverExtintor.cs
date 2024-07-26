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
	private void Awake()
	{
		inputManager = input.GetComponent<InputManager>();
	}
	void Start()
	{
		position = inputManager.GetPosition();
	}

	// Update is called once per frame
	void Update()
	{
		position = inputManager.GetPosition();
		Debug.Log("Mirilla" + position.x + " " + position.y);
		

	}
}
