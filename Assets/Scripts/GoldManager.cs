using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _amountText;
	[SerializeField] private int _countFPS = 30;
	[SerializeField] private float _duration = 1f;
	[SerializeField] private string _numberFormat = "N0";
	[SerializeField] private Vector2Int _addedCoinsRange = new Vector2Int(300, 500);
	[SerializeField] private int _maxCoins = 20000;
	[SerializeField] private float _maxCoinsDuration = 5f;
	
	private int _value = 0;
	private Coroutine _countingCoroutine;
	
	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			UpdateText(value);
			_value = value;
		}
	}

	private void OnEnable()
	{
		RegisterToEvents();
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataDamaged += OnPinataDamaged;
		GeneralEventsDispatcher.PinataDestroyed += OnPinataDestroyed;
	}

	private void OnPinataDestroyed()
	{
		StartCoroutine(GameFinishedCoroutine());
		
	}

	private IEnumerator GameFinishedCoroutine()
	{
		yield return null;
		Value += _maxCoins - _value;
	}

	private void OnPinataDamaged(int damagerange)
	{

		var addedCoins = Random.Range(_addedCoinsRange.x, _addedCoinsRange.y);
		Value += addedCoins;
	}
	
	private void UpdateText(int newValue)
	{
		if (_countingCoroutine != null)
		{
			StopCoroutine(_countingCoroutine);
		}

		var duration = newValue == _maxCoins ? _maxCoinsDuration : _duration;
		_countingCoroutine = StartCoroutine(CountText(newValue, _countFPS, duration));
		GeneralEventsDispatcher.DispatchGoldUpdateValueEvent(newValue);
	}
	
	private IEnumerator CountText(int newValue, int countFPS = 30, float duration = 1f)
	{
		WaitForSeconds wait = new WaitForSeconds(1f / countFPS);
		int previousValue = _value;
		int stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * duration));
		
		while(previousValue < newValue)
		{
			previousValue += stepAmount;
			if (previousValue > newValue)
			{
				previousValue = newValue;
			}

			_amountText.SetText(previousValue.ToString(_numberFormat));

			yield return wait;
		}
	}
}
