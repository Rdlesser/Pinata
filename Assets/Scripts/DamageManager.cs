using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{

	[SerializeField] private Vector2 _damage1Range;
	[SerializeField] private Vector2 _damage2Range;
	[SerializeField] private Vector2 _damage3Range;
	[SerializeField] private Slider _slider;

	private Coroutine _sliderCoroutine;
	
	private void OnEnable()
	{
		StartTimer();
	}

	private void StartTimer()
	{
		_sliderCoroutine = StartCoroutine(DecreaseDamage());
	}

	private IEnumerator DecreaseDamage()
	{
		while (_slider.value > 0)
		{
			if (_slider.value - 5 <= 0)
			{
				_slider.value = 0;
				StopCoroutine(_sliderCoroutine);
				//TODO: Event for game finish
			}
			
			yield return new WaitForSeconds(0.3f);
			_slider.value -= 5;
		}
	}
}
