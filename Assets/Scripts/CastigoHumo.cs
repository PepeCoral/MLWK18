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
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (blow)
		{
			humoPart1.transform.DOMove(humoPart1.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart2.transform.DOMove(humoPart2.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart3.transform.DOMove(humoPart3.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart4.transform.DOMove(humoPart4.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart5.transform.DOMove(humoPart5.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart6.transform.DOMove(humoPart6.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart7.transform.DOMove(humoPart7.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
			humoPart8.transform.DOMove(humoPart8.GetComponent<ParteHumo>().endPosition, 2f).SetEase(Ease.Linear);
		}
		else
		{
			humoPart1.transform.DOMove(humoPart1.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart2.transform.DOMove(humoPart2.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart3.transform.DOMove(humoPart3.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart4.transform.DOMove(humoPart4.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart5.transform.DOMove(humoPart5.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart6.transform.DOMove(humoPart6.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart7.transform.DOMove(humoPart7.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
			humoPart8.transform.DOMove(humoPart8.GetComponent<ParteHumo>().initPosition, 2f).SetEase(Ease.Linear);
		}
	}
}
