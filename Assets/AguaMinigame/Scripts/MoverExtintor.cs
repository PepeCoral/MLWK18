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

	public GameObject fuegoDerecha;
	public GameObject fuegoIzquierda;

	[SerializeField] private Quaternion targetRotation;

	AudioSource source;
	private void Awake()
	{
		inputManager = input.GetComponent<InputManager>();
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		position = inputManager.GetPosition();
		// Debug.Log("Mirilla" + position.x + " " + position.y);
		var step = speedMove * Time.deltaTime; // calculate distance to move
		Vector3 newPosition;
		if (position.x > 0 || position.y > 0)
		{

			newPosition = UpperCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, 0));

		}
		else
		{

			newPosition = new Vector3(0, 0, 0);


		}

		// float rotation = newPosition.x * Time.deltaTime * speedMove;

		// rotation = Vector3.Angle(position, newPosition);
		// transform.rotation = Quaternion.Euler(0, 0, rotation);

		Vector3 direction = (newPosition - transform.position).normalized;

		// Calcula la rotación hacia la nueva dirección
		targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

		// Interpola suavemente la rotación
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedMove);


		if (targetRotation.z > 0.25)
		{

			fuegoDerecha.GetComponent<Fuego>().setWater(true);
		}
		else if (targetRotation.z < -0.25)
			fuegoIzquierda.GetComponent<Fuego>().setWater(true);

		else
		{

			fuegoDerecha.GetComponent<Fuego>().setWater(false);
			fuegoIzquierda.GetComponent<Fuego>().setWater(false);
			// fuegoIzquierda.SetActive(false);
		}
	}



}

