using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _intro;
	[SerializeField] private AudioSource _winSound;

	private void OnEnable()
	{
		GeneralEventsDispatcher.ThreeStarsReached += PlayWinSound;
	}

	private void Start()
	{
		PlayIntro();
	}

	[ContextMenu("PlayIntro()")]
	public void PlayIntro()
	{
		_intro.Play();
	}

	private void PlayWinSound()
	{
		_winSound.Play();
	}
}
