using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
	[SerializeField] private GameObject _winScreen;
	[SerializeField] private float _animationTime = 6f;
	[SerializeField] private Ease _ease = Ease.InOutCubic;

	private void OnEnable()
	{
		_winScreen.transform.localScale = Vector3.zero;
		GeneralEventsDispatcher.PinataDestroyed += ShowWinScreen;
	}

	private void ShowWinScreen()
	{
		GeneralEventsDispatcher.PinataDestroyed -= ShowWinScreen;
		_winScreen.transform.DOScale(1, _animationTime).SetEase(_ease);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
