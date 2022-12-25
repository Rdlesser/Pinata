using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarsBar : MonoBehaviour
{
	[SerializeField] private List<Image> _starImages;
	[SerializeField] private float _starFillAnimationTime = 1.5f;
	[SerializeField] private Vector3Int _starPointRange = new Vector3Int(1500, 3000, 9000);
	[SerializeField] private List<TextMeshProUGUI> _starTexts;

	private int _awardedStars;

	private void OnEnable()
	{
		ResetValues();
		RegisterToEvents();
	}

	private void ResetValues()
	{
		foreach (var starImage in _starImages)
		{
			starImage.fillAmount = 0;
		}

		ResetStarTexts();
	}

	private void ResetStarTexts()
	{
		for (int i = 0; i < _starTexts.Count; i++)
		{
			_starTexts[i].gameObject.SetActive(true);
			_starTexts[i].text = _starPointRange[i].ToString();
		}
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.GoldUpdatedValue += OnGoldUpdatedValue;
	}

	private void OnGoldUpdatedValue(int newvalue)
	{
		if (newvalue >= _starPointRange.z)
		{
			GeneralEventsDispatcher.GoldUpdatedValue -= OnGoldUpdatedValue;
			UpdateStars(3);
			GeneralEventsDispatcher.DispatchThreeStarsReached();
			return;
		}

		if (newvalue >= _starPointRange.y && _awardedStars < 2)
		{
			UpdateStars(2);
			GeneralEventsDispatcher.DispatchTwoStarsReached();
			return;
		}
		
		if (newvalue >= _starPointRange.x && _awardedStars < 1)
		{
			UpdateStars(1);
			GeneralEventsDispatcher.DispatchOneStarReached();
			return;
		}
	}

	private void UpdateStars(int newValue)
	{
		_awardedStars = newValue;
		_starImages[newValue - 1].DOFillAmount(1, _starFillAnimationTime);
		_starTexts[newValue - 1].gameObject.SetActive(false);
	}
}
