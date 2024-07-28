using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnLoad : MonoBehaviour
{

	[SerializeField] private AudioClip musicClip;
	[SerializeField] private bool StopMusicOnDestroy = false;
	
	void Start () {
		MyAudioSource.Instance.PlayMusic(musicClip, true);
	}

	private void OnDestroy()
	{
		if (StopMusicOnDestroy)
		{
			MyAudioSource.Instance.StopMusic();
		}
	}
}
