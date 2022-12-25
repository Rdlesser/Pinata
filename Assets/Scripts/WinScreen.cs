using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
	[SerializeField] private GameObject _winScreen;
	[SerializeField] private Transform _goldBar;
	[SerializeField] private Transform _awardsBar;
	[SerializeField] private float _animationTime = 6f;
	[SerializeField] private Ease _ease = Ease.InOutCubic;

	private void OnEnable()
	{
		_winScreen.transform.localScale = Vector3.zero;
		RegisterToEvents();
		
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataDestroyed += ShowWinScreen;
		GeneralEventsDispatcher.TimeIsUp += ShowWinScreen;
	}

	private void UnregisterFromEvents()
	{
		GeneralEventsDispatcher.PinataDestroyed -= ShowWinScreen;
		GeneralEventsDispatcher.TimeIsUp -= ShowWinScreen;
	}

	private void ShowWinScreen()
	{
		UnregisterFromEvents();
		
		_winScreen.transform.DOScale(1, _animationTime).SetEase(_ease);
		_goldBar.transform.SetParent(transform);
		_awardsBar.transform.SetParent(transform);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		Application.Quit();
	}

	private void OnDisable()
	{
		UnregisterFromEvents();
	}
}
