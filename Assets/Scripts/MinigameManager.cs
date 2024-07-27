using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MinigameManager : MonoBehaviour
{

	[FormerlySerializedAs("TimeToFinish")]
	[Header("Generic Options")]
	//Time to finish this minigame once started, if this expires, the minigame has failed
	[SerializeField] protected float MinigameTimeLength = 15;
	[SerializeField] protected float CountdownToStart = 5;
	[SerializeField] protected float NextSceneTimer = 3;
	[SerializeField] SceneSwitcher Switcher;

	protected float CurrentStartCountdown;
	[SerializeField] protected float CurrentTimeLength;
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

			if (CurrentStartCountdown <= 0)
			{
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

				Switcher.SwitchToNextScene();
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
