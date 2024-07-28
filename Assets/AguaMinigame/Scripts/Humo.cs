using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Humo : MinigameManager
{
	[FormerlySerializedAs("renderer")] public SpriteRenderer spriteRenderer;
	public Color color;
	public bool fade = false;
	protected override void Awake()
	{
		base.Awake();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

	}

	protected override void Update()
	{
		base.Update();

		if (MinigameTimeLength / 2 > CurrentTimeLength && !fade)
		{

			spriteRenderer.DOFade(1, MinigameTimeLength / 2);
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