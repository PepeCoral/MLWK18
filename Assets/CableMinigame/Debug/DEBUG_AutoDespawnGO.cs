using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_AutoDespawnGO : MonoBehaviour {

	[SerializeField]
	public float DespawnRate = 1f;
	
	private SpriteRenderer sr;
	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Color newColor = sr.color;
		newColor.a -= DespawnRate * Time.deltaTime;

		if (newColor.a <= 0)
		{
			Destroy(gameObject);
		}
		else
		{
			sr.color = newColor;
		}
	}
}
