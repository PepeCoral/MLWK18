using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Humo : MinigameManager
{
	public SpriteRenderer renderer;
	public Color color;
	public bool fade = false;
	protected override void Awake()
	{
		base.Awake();
		renderer = this.GetComponent<SpriteRenderer>();

	}

	protected override void Update()
	{
		base.Update();

		if (MinigameTimeLength / 2 > CurrentTimeLength && !fade)
		{

			renderer.DOFade(1, MinigameTimeLength / 2);
			fade = true;
		}


	}

	protected override void StartMinigame()
	{
		base.StartMinigame();
	}

	public bool GetStartMinigame()
	{
		return bIsMinigameTimerActive;
	}
}