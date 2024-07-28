using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
	public Text text;
	public GameObject bombilla;
	private Animator bombillaAnimation;

	private void Awake()
	{
		if (bombilla != null)
		{
			bombillaAnimation = bombilla.GetComponent<Animator>();

		}

	}

	void Start()
	{
		if (text != null)
		{
			text.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
		}

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || GamePad.GetButtonTrigger(N3dsButton.A))
		{
			if (bombillaAnimation != null)
			{
				StartCoroutine(WaitForAnimationAndSwitchScene());
			}
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