using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
	[SerializeField] private GameObject _timesUpText;
	[SerializeField] private Image _winScreen;
	[SerializeField] private GameObject _content;
	[SerializeField] private Transform _goldBar;
	[SerializeField] private Transform _awardsBar;
	[SerializeField] private float _fadeDuration = 0.25f;
	[SerializeField] private float _animationTime = 6f;
	[SerializeField] private Ease _ease = Ease.InOutCubic;

	private void OnEnable()
	{
		ResetBackground();
		ResetContent();
		RegisterToEvents();
		
	}

	private void ResetBackground()
	{
		var winScreenColor = _winScreen.color;
		winScreenColor.a = 0f;
		_winScreen.color = winScreenColor;
	}

	private void ResetContent()
	{
		_content.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataDestroyed += PinataDestroyed;
		GeneralEventsDispatcher.TimeIsUp += ShowWinScreen;
	}

	private void UnregisterFromEvents()
	{
		GeneralEventsDispatcher.PinataDestroyed -= PinataDestroyed;
		GeneralEventsDispatcher.TimeIsUp -= ShowWinScreen;
	}

	private void PinataDestroyed()
	{
		_timesUpText.SetActive(false);
		ShowWinScreen();
	}

	private void ShowWinScreen()
	{
		UnregisterFromEvents();

		_winScreen.DOFade(0.7f, _fadeDuration);
		_content.transform.DOScale(1, _animationTime);
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
