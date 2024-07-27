using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Fuego : MonoBehaviour
{

	public float timeToDown = 2;
	public bool isWater = false;

	public float timeToRespawn = 2;

	[SerializeField] private float timer = 0;

	private bool isDown = false;
	private SpriteRenderer _renderer;
	// Use this for initialization
	void Start()
	{
		_renderer = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{



		if (timer < 0 && isDown == false && isWater == true)
		{
			_renderer.DOFade(0f, 2f);
			timer = timeToDown;
			isDown = true;
		}
		else if (timer < 0 && isDown == true && isWater == false)
		{
			_renderer.DOFade(1f, 5f);
			timer = timeToRespawn;
			isDown = false;

		}


		if (isWater == true)
		{

			timer -= Time.deltaTime;
		}
	}

	public void setWater(bool water)
	{
		isWater = water;
	}
}
