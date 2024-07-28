using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoverExtintor : MonoBehaviour
{

	// Use this for initialization

	public GameObject input;

	private Vector2 position;
	private InputManager inputManager;
	[SerializeField] private float speedMove = 20f;

	[SerializeField] private LayerMask FireMask;
	
	public Camera UpperCamera;

	public List<Fuego> FiresHit;

	[SerializeField] private Quaternion targetRotation;
	public GameObject manager;

	bool started = false;
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

		started = manager.GetComponent<Humo>().GetStartMinigame();
		if (started)
		{
			position = inputManager.GetPosition();
			// Debug.Log("Mirilla" + position.x + " " + position.y);
			Vector3 newPosition;
			if (position.x > 0 || position.y > 0)
			{

				newPosition = UpperCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, 0));

			}
			else
			{
				newPosition = new Vector3(0, 0, 0);
			}



			Vector3 direction = (newPosition - transform.position).normalized;

			// Calcula la rotación hacia la nueva dirección
			targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

			// Interpola suavemente la rotación
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedMove);
			
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1000, FireMask);
			Debug.DrawRay(transform.position, transform.up, Color.red, 10);

			Fuego FireHitThisFrame = null;
			if (hit)
			{
				FireHitThisFrame = hit.transform.GetComponent<Fuego>();
				FireHitThisFrame.setWater(true);
				if (!FiresHit.Contains(FireHitThisFrame))
				{
					FiresHit.Add(FireHitThisFrame);
				}
			}
			
			foreach (Fuego AvailableFire in FiresHit)
			{
				if (FireHitThisFrame != null && AvailableFire != FireHitThisFrame)
				{
					AvailableFire.setWater(false);
				}
			}
		}
	}



}

