using System;
using System.Collections;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{
	
	[SerializeField] private Animator _backgroundImage;

	private Coroutine _sliderCoroutine;
	
	private static readonly int Hit = Animator.StringToHash("Hit");

	private void OnEnable()
	{
		RegisterToEvents();
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataTapped += OnPinataHit;
	}

	private void UnregisterFromEvents()
	{
		GeneralEventsDispatcher.PinataTapped -= OnPinataHit;
	}

	private void OnPinataHit()
	{
		_backgroundImage.SetTrigger(Hit);
		_backgroundImage.transform.DOShakePosition(0.1f, 0.2f);
		GeneralEventsDispatcher.DispatchPinataDamagedEvent(3);
	}

	private void OnDisable()
	{
		UnregisterFromEvents();
	}
}
