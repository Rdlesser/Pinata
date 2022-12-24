using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _intro;

	private void Start()
	{
		PlayIntro();
	}

	[ContextMenu("PlayIntro()")]
	public void PlayIntro()
	{
		_intro.Play();
	}
}
