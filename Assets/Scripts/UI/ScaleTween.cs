using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
	
public class ScaleTween : MonoBehaviour
{

	[SerializeField] Vector3 TargetScale;
	[SerializeField] float Duration = 2f;
	[SerializeField] bool StartOnStart = true;

	private Tweener ScaleTweenInstance;
	// Use this for initialization
	void Start ()
	{
		DOTween.Init();
		
		if (StartOnStart)
		{
			StartTween();
		}
	}

	public void StartTween()
	{
		ScaleTweenInstance = transform.DOScale(TargetScale, Duration).SetLoops(-1, LoopType.Yoyo);
	}

	private void OnDestroy()
	{
		ScaleTweenInstance.Kill();
	}
}
