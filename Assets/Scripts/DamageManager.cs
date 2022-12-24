﻿using System;
using System.Collections;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{

	[SerializeField] private Vector2 _damage1Range;
	[SerializeField] private Vector2 _damage2Range;
	[SerializeField] private Vector2 _damage3Range;
	[SerializeField] private Slider _slider;
	[SerializeField] private float _damageIncrease = 15f;
	[SerializeField] private float _damageDecrease = 5f;
	[SerializeField] private float _decreaseInterval = 0.3f;
	[SerializeField] private Animator _backgroundImage;

	private Coroutine _sliderCoroutine;
	
	private static readonly int Hit = Animator.StringToHash("Hit");

	private void OnEnable()
	{
		ResetSlider();
		RegisterToEvents();
		StartTimer();
	}

	private void ResetSlider()
	{
		_slider.value = _damage1Range.y;
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataTapped += OnPinataHit;
	}

	private void OnPinataHit()
	{
		_backgroundImage.SetTrigger(Hit);
		_backgroundImage.transform.DOShakePosition(0.1f, 0.2f);
		if (_slider.value + _damageIncrease >= _damage3Range.y)
		{
			GeneralEventsDispatcher.PinataTapped -= OnPinataHit;
			_slider.value = _slider.maxValue;
			StopCoroutine(_sliderCoroutine);
			GeneralEventsDispatcher.DispatchPinataDestroyedEvent();
			return;
		}
		
		_slider.value += _damageIncrease;
		GeneralEventsDispatcher.DispatchPinataDamagedEvent(GetDamageRange());
	}

	private int GetDamageRange()
	{
		if (_slider.value <= _damage1Range.y)
		{
			return 1;
		}

		if (_slider.value <= _damage2Range.y &&
			_slider.value >= _damage2Range.x)
		{
			return 2;
		}

		return 3;
	}

	private void StartTimer()
	{
		_sliderCoroutine = StartCoroutine(DecreaseDamage());
	}

	private IEnumerator DecreaseDamage()
	{
		while (_slider.value > 0)
		{
			if (_slider.value - _damageDecrease <= 0)
			{
				_slider.value = 0;
				StopCoroutine(_sliderCoroutine);
				//TODO: Event for game finish
			}
			
			yield return new WaitForSeconds(_decreaseInterval);
			_slider.value -= _damageDecrease;
		}
	}

	private void OnDisable()
	{
		GeneralEventsDispatcher.PinataTapped -= OnPinataHit;
	}
}
