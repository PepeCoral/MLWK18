using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Fuego : MonoBehaviour
{

	public float OriginalTimeToDown = 2;
	private float currentTimeToDown;
	public bool isWater = false;

	public float timeToRespawn = 2;
	public float timeToFadeIn = 2;
	public float timeToFadeOut = 2;

	public float timeScaling = 0.2f;
	[SerializeField] private float timer = 0;

	private bool isDown = false;
	private SpriteRenderer _renderer;
	// Use this for initialization
	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		currentTimeToDown = OriginalTimeToDown;
	}

	// Update is called once per frame
	void Update()
	{
		if (timer < 0 && isDown == false && isWater == true)
		{
			_renderer.DOFade(0f, timeToFadeOut);

			OriginalTimeToDown -= timeScaling;

			if (OriginalTimeToDown <= 0.35f)
			{
				OriginalTimeToDown = 0.35f;
			}
			
			currentTimeToDown = OriginalTimeToDown + Random.Range(-0.5f, 0.5f);
			
			timer = currentTimeToDown;
			isDown = true;
		}
		else if (timer < 0 && isDown == true && isWater == false)
		{
			_renderer.DOFade(1f, timeToFadeIn);
			timer = timeToRespawn;
			isDown = false;
		}
		
		timer -= Time.deltaTime;
	}

	public void setWater(bool water)
	{
		isWater = water;
	}
}
