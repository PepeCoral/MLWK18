using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CastigoHumo : MonoBehaviour
{

	// Use this for initialization

	public GameObject humoPart1;
	public GameObject humoPart2;
	public GameObject humoPart3;
	public GameObject humoPart4;
	public GameObject humoPart5;
	public GameObject humoPart6;
	public GameObject humoPart7;
	public GameObject humoPart8;
	public bool blow = false;
	
	[SerializeField] private int minTime = 5;
	[SerializeField] private int maxTime = 10;
	[SerializeField] private float blowForce = 0.2f;

	private int timeToSmoke;
	private float currentTime = 0;
	
	private bool smoking = false;
	
	private float currentPercentage = 0;
	
	private bool activationCompleted = false;
	
	void Start()
	{
		timeToSmoke = Random.Range(minTime, maxTime);
	}

	// Update is called once per frame
	void Update()
	{
		if(!smoking)
		{
			activationCompleted = false;
			currentTime += Time.deltaTime;

			if (currentTime >= timeToSmoke)
			{
				currentTime = 0;
				timeToSmoke = Random.Range(minTime, maxTime);
				ActivateSmoke();
				smoking = true;
			}

			return;
		}
		
		if (blow && activationCompleted)
		{
			currentPercentage += Time.deltaTime * blowForce;
			
			SetSmokeToPercentage(currentPercentage);
		}
	}

	private void SetSmokeToPercentage(float f)
	{
		if(f >= 1)
		{
			blow = false;
			currentPercentage = 0;
			smoking = false;
		}
		
		humoPart1.transform.position = Vector3.Lerp(humoPart1.GetComponent<ParteHumo>().initPosition, humoPart1.GetComponent<ParteHumo>().endPosition, f);
		humoPart2.transform.position = Vector3.Lerp(humoPart2.GetComponent<ParteHumo>().initPosition, humoPart2.GetComponent<ParteHumo>().endPosition, f);
		humoPart3.transform.position = Vector3.Lerp(humoPart3.GetComponent<ParteHumo>().initPosition, humoPart3.GetComponent<ParteHumo>().endPosition, f);
		humoPart4.transform.position = Vector3.Lerp(humoPart4.GetComponent<ParteHumo>().initPosition, humoPart4.GetComponent<ParteHumo>().endPosition, f);
		humoPart5.transform.position = Vector3.Lerp(humoPart5.GetComponent<ParteHumo>().initPosition, humoPart5.GetComponent<ParteHumo>().endPosition, f);
		humoPart6.transform.position = Vector3.Lerp(humoPart6.GetComponent<ParteHumo>().initPosition, humoPart6.GetComponent<ParteHumo>().endPosition, f);
		humoPart7.transform.position = Vector3.Lerp(humoPart7.GetComponent<ParteHumo>().initPosition, humoPart7.GetComponent<ParteHumo>().endPosition, f);
		humoPart8.transform.position = Vector3.Lerp(humoPart8.GetComponent<ParteHumo>().initPosition, humoPart8.GetComponent<ParteHumo>().endPosition, f);
	}

	private void ActivateSmoke()
	{
		humoPart1.transform.DOMove(humoPart1.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart2.transform.DOMove(humoPart2.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart3.transform.DOMove(humoPart3.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart4.transform.DOMove(humoPart4.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart5.transform.DOMove(humoPart5.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart6.transform.DOMove(humoPart6.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart7.transform.DOMove(humoPart7.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		humoPart8.transform.DOMove(humoPart8.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear).OnComplete(() => activationCompleted = true);

	}
}
