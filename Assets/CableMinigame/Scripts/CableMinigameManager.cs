using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableMinigameManager : MonoBehaviour
{

	[SerializeField] private float TimeToResolve = 15;
	[SerializeField] private Text InformationText;
	
	private float currentGameTime;
	
	[SerializeField] private CableStartLocation[] AvailableCables;
	[SerializeField] private Fuse[] Fuses;

	private bool IsCountdownEnabled = false;
	
	// Use this for initialization
	void Start ()
	{
		currentGameTime = TimeToResolve;
		
		StartMinigame();
	}

	void StartMinigame()
	{
		IsCountdownEnabled = true;
	}
	// Update is called once per frame
	void Update () {

		if (IsCountdownEnabled)
		{
			currentGameTime -= Time.deltaTime;
			InformationText.text = currentGameTime.ToString("0.00");
			
			if (currentGameTime <= 0)
			{
				InformationText.text = "Game Timed Out!!!";
				currentGameTime = 0;
				IsCountdownEnabled = false;
				Application.Quit();
			}
		}
	}

	public bool CanGameEnd()
	{
		int CorrectCables = 0;
		foreach (CableStartLocation cable in AvailableCables)
		{
			if (cable.isCompleted)
			{
				CorrectCables++;
			}
		}

		if (CorrectCables != AvailableCables.Length)
		{
			return false;
		}
		
		int CorrectFuses = 0;
		foreach (Fuse fuse in Fuses)
		{
			if (fuse.isSlotted)
			{
				CorrectFuses++;
			}
		}

		return CorrectFuses == Fuses.Length;
	}

	public void GameCompleted()
	{
		IsCountdownEnabled = false;
		InformationText.text = "Game COMPLETED Out!!!";
	}
}
