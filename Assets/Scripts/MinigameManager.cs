using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MinigameManager : MonoBehaviour
{

    [FormerlySerializedAs("TimeToFinish")]
    [Header("Generic Options")]
    //Time to finish this minigame once started, if this expires, the minigame has failed
    [SerializeField] private float MinigameTimeLength = 15;
    [SerializeField] private float CountdownToStart = 5;


    protected float CurrentStartCountdown;
    protected float CurrentTimeLength;

    private bool bIsMinigameTimerActive = false;
    private bool bIsStartCountdownActive = true;

    // Use this for initialization
    void Awake()
    {
        CurrentTimeLength = MinigameTimeLength;
        CurrentStartCountdown = CountdownToStart;
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
    }

    protected virtual void OnGameTimerExpired()
    {
        bIsMinigameTimerActive = false;
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
    }
}
