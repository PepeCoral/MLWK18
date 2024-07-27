using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
	
public class ScaleTween : MonoBehaviour
{

	[SerializeField] Vector3 TargetScale;
	[SerializeField] float Duration = 2f;
	[SerializeField] bool StartOnStart = true;
	// Use this for initialization
	void Start ()
	{
		DOTween.Init();
		
		if (StartOnStart)
		{
			StartTween();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTween()
	{
		transform.DOScale(TargetScale, Duration).SetLoops(-1, LoopType.Yoyo);
	}
}
