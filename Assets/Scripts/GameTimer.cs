using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timerText;
	[SerializeField] private int _gameTimeInSeconds = 60;
	[SerializeField] private bool _isCountingDown = true;

	private float _currentTime;
	private bool _isTimerRunning = false;

	private void OnEnable()
	{
		RegisterToEvents();
	}

	private void RegisterToEvents()
	{
		SceneManager.sceneLoaded += StartTimer;
		GeneralEventsDispatcher.ThreeStarsReached += OnGameFinished;
	}

	private void UnregisterFromEvents()
	{
		SceneManager.sceneLoaded -= StartTimer;
		GeneralEventsDispatcher.ThreeStarsReached -= OnGameFinished;
	}

	private void StartTimer(Scene arg0, LoadSceneMode arg1)
	{
		StartTimer();
	}

	private void StartTimer()
	{
		Init(_gameTimeInSeconds, _isCountingDown);
		SetTimerRunning(true);
	}

	private void OnGameFinished()
	{
		UnregisterFromEvents();
		PauseClock();
	}

	private void PauseClock()
	{
		SetTimerRunning(false);
	}

	private void Init(int gameTimeInSeconds, bool isCountingDown)
	{
		_currentTime = isCountingDown ? gameTimeInSeconds : 0;
	}

	public void SetTimerRunning(bool isRunning)
	{
		_isTimerRunning = isRunning;
	}

	private void UpdateTimerText()
	{
		var minutes = (int) _currentTime / 60;
		var seconds = (int) _currentTime % 60;
		var timerText = $"{minutes}:{seconds}";
		_timerText.text = timerText;
	}

	private void Update()
	{
		if (!_isTimerRunning)
		{
			return;
		}

		UpdateCurrentTime();
		if (HasTimerFinished())
		{
			StopClock();
			GeneralEventsDispatcher.DispatchTimeIsUpEvent();
		}
		UpdateTimerText();
	}

	private void StopClock()
	{
		_currentTime = _isCountingDown ? 0 : _gameTimeInSeconds;
		_timerText.color = Color.red;
		SetTimerRunning(false);
	}

	private bool HasTimerFinished()
	{
		var result = _isCountingDown && _currentTime <= 0 || !_isCountingDown && _currentTime >= _gameTimeInSeconds;
		return result;
	}

	private void UpdateCurrentTime()
	{
		_currentTime = _isCountingDown ? _currentTime -= Time.deltaTime : _currentTime += Time.deltaTime;
	}

	private void OnDisable()
	{
		UnregisterFromEvents();
	}
}
