using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableMinigameManager : MinigameManager
{
    [Header("Cable Minigame Parameters")]
    [SerializeField] private CableStartLocation[] AvailableCables;
    [SerializeField] private Fuse[] Fuses;

    [Header("UI Information")]
    [SerializeField] private Slider TimerSlider;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsMinigameActive())
        {
            if (CurrentTimeLength > 0)
            {
                TimerSlider.value = 1 - (CurrentTimeLength/MinigameTimeLength);
            }
        }
    }

    protected override void OnGameTimerExpired()
    {
        base.OnGameTimerExpired();
    }

    public override bool CanMinigameEnd()
    {
        int expectedAmount = 0;
        foreach (CableStartLocation cable in AvailableCables)
        {
            if (cable.isCompleted)
            {
                expectedAmount++;
            }
        }

        if (expectedAmount != AvailableCables.Length)
        {
            return false;
        }

        expectedAmount = 0;
        foreach (Fuse fuse in Fuses)
        {
            if (fuse.isSlotted)
            {
                expectedAmount++;
            }
        }

        return expectedAmount == Fuses.Length;
    }

    public override void CompleteMinigame()
    {
        base.CompleteMinigame();
    }
}
