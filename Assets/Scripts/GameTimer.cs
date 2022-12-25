using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timerText;
	[SerializeField] private int _gameTimeInSeconds = 60;
	[SerializeField] private bool _isCountingDown = true;
	[SerializeField] private string _timeFormat = "{minutes}:{seconds}";

	private float _currentTime;
	private bool _isTimerRunning = false;


	private void Start()
	{
		Init(_gameTimeInSeconds, _isCountingDown);
		SetTimer(true);
	}

	private void Init(int gameTimeInSeconds, bool isCountingDown)
	{
		if (isCountingDown)
		{
			throw new NotImplementedException();
		}
	}

	public void SetTimer(bool isRunning)
	{
		_isTimerRunning = isRunning;
	}

	private void UpdateTimerText()
	{
		var minutes = _currentTime / 60;
		var seconds = _currentTime % 60;
		var timerText = $"{_timeFormat}";
		_timerText.text = timerText;
	}

	private void Update()
	{
		if (!_isTimerRunning)
		{
			return;
		}

		UpdateCurrentTime();
		UpdateTimerText();
	}

	private void UpdateCurrentTime()
	{
		_currentTime = _isCountingDown ? _currentTime -= Time.deltaTime : _currentTime += Time.deltaTime;
	}
}
