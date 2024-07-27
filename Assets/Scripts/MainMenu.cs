using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.UI;
using DG.Tweening;
public class MainMenu : MonoBehaviour
{

	// Use this for initialization

	public Text text;
	public GameObject bombilla;

	private SpriteRenderer spriteRenderer;
	private GameObject scenemanager;

	public float step = 0f;



	private void Awake()
	{
		scenemanager = GameObject.FindWithTag("SceneSwitcher");
	}
	void Start()
	{
		text.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
		spriteRenderer = bombilla.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) || GamePad.GetButtonTrigger(N3dsButton.A))
		{
			Sequence mySequence = DOTween.Sequence();
			mySequence.Append(spriteRenderer.DOColor(new Color(255f, 255f, 255f, 255f), 0.1f));
			if (step < 2)
			{
				mySequence.Append(spriteRenderer.DOColor(new Color(255f, 255f, 0f, 255f), 0.1f));
			}
			mySequence.PrependInterval(1);
			step++;
		}


		if (step == 3)
		{
			scenemanager.GetComponent<SceneSwitcher>().SwitchToNextScene();
		}

		// text.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
	}
}
