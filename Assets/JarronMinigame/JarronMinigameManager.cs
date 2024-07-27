using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronMinigameManager : MinigameManager
{
    [SerializeField] JarronAscenso _jarronAscenso;
    [SerializeField] JarronGiroscopio _jarronGiroscopio;
    protected override void Update()
    {
        base.Update();
    }

    protected override void StartMinigame()
    {
        base.StartMinigame();
        _jarronAscenso.StartGame();
        _jarronGiroscopio.StartMinigame();
    }


    public override void CompleteMinigame()
    {
        base.CompleteMinigame();

        _jarronAscenso.CompleteMinigame();
        _jarronGiroscopio.CompleteMinigame();
    }

}
