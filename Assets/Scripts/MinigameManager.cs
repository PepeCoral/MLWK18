using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{

	[FormerlySerializedAs("TimeToFinish")]
	[Header("Generic Options")]
	//Time to finish this minigame once started, if this expires, the minigame has failed
	[SerializeField] protected float MinigameTimeLength = 15;
	[SerializeField] protected float CountdownToStart = 5;
	[SerializeField] protected float NextSceneTimer = 3;
	
	[Header("Pre Game Menu")]
	//Time to finish this minigame once started, if this expires, the minigame has failed
	[SerializeField] Text CountDownText;
	[SerializeField] CanvasGroup CountdownImageContainer;
	
	protected float CurrentStartCountdown;
	protected float CurrentTimeLength;
	protected float CurrentNextSceneTimer;
	
	protected bool bIsMinigameTimerActive = false;
	protected bool bIsStartCountdownActive = true;
	protected bool bIsNextSceneTimerActive = false;
	
	// Use this for initialization
	protected virtual void Awake()
	{
		CurrentTimeLength = MinigameTimeLength;
		CurrentStartCountdown = CountdownToStart;
		CurrentNextSceneTimer = NextSceneTimer;
	}

	protected virtual void Start()
	{
	}

	protected virtual void StartMinigame()
	{
		bIsMinigameTimerActive = true;
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		if (bIsMinigameTimerActive)
		{
			CurrentTimeLength -= Time.deltaTime;

			if (CurrentTimeLength <= 0)
			{
				CurrentTimeLength = 0;
				OnGameTimerExpired();
			}
		}

		if (bIsStartCountdownActive)
		{
			CurrentStartCountdown -= Time.deltaTime;
			
			CountDownText.text = CurrentStartCountdown.ToString("0");
			
			if (CurrentStartCountdown <= 1)
			{
				CountdownImageContainer.alpha = CurrentStartCountdown / 1;
			}
			
			if (CurrentStartCountdown <= 0)
			{
				CountdownImageContainer.alpha = 0;
				
				CurrentStartCountdown = 0;
				bIsStartCountdownActive = false;

				StartMinigame();
			}
		}

		if (bIsNextSceneTimerActive)
		{
			CurrentNextSceneTimer -= Time.deltaTime;

			if (CurrentNextSceneTimer <= 0)
			{
				CurrentNextSceneTimer = 0;
				bIsNextSceneTimerActive = false;

				SceneSwitcher.Instance.SwitchToNextScene();
			}
		}
	}

	protected virtual void OnGameTimerExpired()
	{
		bIsMinigameTimerActive = false;
		bIsNextSceneTimerActive = true;
	}

	public virtual bool IsMinigameActive()
	{
		return bIsMinigameTimerActive;
	}

	public virtual bool CanMinigameEnd()
	{
		return true;
	}

	public virtual void CompleteMinigame()
	{
		bIsMinigameTimerActive = false;
		bIsNextSceneTimerActive = true;
	}
}
