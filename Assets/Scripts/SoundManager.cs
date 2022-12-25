using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _intro;
	[SerializeField] private AudioSource _bigWinSound;
	[SerializeField] private AudioSource _winSound;
	[SerializeField] private List<AudioSource> _hitSounds;
	[SerializeField] private AudioSource _backgroundMusic;

	private void OnEnable()
	{
		RegisterToGameEvents();
	}

	private void RegisterToGameEvents()
	{
		GeneralEventsDispatcher.ThreeStarsReached += OnThreeStarsReached;
		GeneralEventsDispatcher.TimeIsUp += OnGameOver;
		GeneralEventsDispatcher.PinataTapped += PlayHitSound;
		SceneManager.sceneLoaded += PlayBackgroundMusic;
	}
	
	private void UnregisterFromAllEvents()
	{
		GeneralEventsDispatcher.ThreeStarsReached -= OnThreeStarsReached;
		GeneralEventsDispatcher.TimeIsUp -= OnGameOver;
		GeneralEventsDispatcher.PinataTapped -= PlayHitSound;
		SceneManager.sceneLoaded -= PlayBackgroundMusic;
	}

	private void PlayBackgroundMusic(Scene arg0, LoadSceneMode arg1)
	{
		PlayBackgroundMusic();
	}

	private void PlayBackgroundMusic()
	{
		_backgroundMusic.Play();
	}

	private void StopBackgroundMusic()
	{
		_backgroundMusic.Stop();
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

	private void OnGameOver()
	{
		StopBackgroundMusic();
		PlayWinSound();
	}

	private void OnThreeStarsReached()
	{
		StopBackgroundMusic();
		PlayWinSound();
		PlayBigWinSound();
	}

	private void PlayBigWinSound()
	{
		_bigWinSound.Play();
	}

	private void PlayWinSound()
	{
		_winSound.Play();
	}

	private void PlayHitSound()
	{
		var randomIndex = Random.Range(0, _hitSounds.Count - 1);
		_hitSounds[randomIndex].Play();
	}
	

	private void OnDisable()
	{
		UnregisterFromAllEvents();
	}
}
