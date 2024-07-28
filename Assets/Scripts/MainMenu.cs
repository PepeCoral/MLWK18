using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
	public GameObject bombilla;
	private Animator bombillaAnimation;
	
	private Button playButton;
	
	[SerializeField] private Canvas canvas;

	private void Awake()
	{
		playButton = FindObjectsOfType<Button>().FirstOrDefault(g => g.name == "PlayButton");
		
		if (bombilla != null)
		{
			bombillaAnimation = bombilla.GetComponent<Animator>();

		}

	}

	private void Start()
	{
		canvas.sortingOrder = 1000;
		playButton.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1).SetLoops(-1, LoopType.Yoyo);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || GamePad.GetButtonTrigger(N3dsButton.A))
		{
			StartGame();
		}
	}


	public void StartGame()
	{
		canvas.sortingOrder = -1000;
		if (bombillaAnimation != null)
		{
			StartCoroutine(WaitForAnimationAndSwitchScene());
		}
	}
	private IEnumerator WaitForAnimationAndSwitchScene()
	{
		bombillaAnimation.SetBool("start", true);

		// Wait for 1 second
		yield return new WaitForSeconds(1f);

		// Switch to the next scene
		SceneSwitcher.Instance.SwitchToNextScene();
	}
}