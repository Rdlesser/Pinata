using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _timerText;
	[SerializeField] private int _gameTimeInSeconds = 60;
	[SerializeField] private bool _isCountingDown = true;

	private bool _isTimerRunning = false;


	private void Start()
	{
		StartTimer();
	}

	private void StartTimer()
	{
		throw new NotImplementedException();
	}
}
