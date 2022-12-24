using System;
using System.Collections.Generic;
using UnityEngine;

public class PinataExplosion : MonoBehaviour
{
	[SerializeField] private Renderer _pinata;
	[SerializeField] private List<Rigidbody2D> _pinataParts;
	[SerializeField] private float _explosionForce;
	[SerializeField] private float _explosionRadius;

	private List<Vector2> _pinataPartsPositions = new List<Vector2>(); 

	private void OnEnable()
	{
		SetActiveExplodingParts(false);
		CacheOriginalPositions();
		RegisterToEvents();
	}

	private void CacheOriginalPositions()
	{
		foreach (var part in _pinataParts)
		{
			var position = part.position;
			_pinataPartsPositions.Add(position);
		}
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.ThreeStarsReached += OnPinataDestroyed;
	}

	[ContextMenu("Explosion")]
	private void OnPinataDestroyed()
	{
		_pinata.enabled = false;
		SetActiveExplodingParts();
		AddExplosionForceToParts();
	}

	private void SetActiveExplodingParts(bool isActive = true)
	{
		foreach (var part in _pinataParts)
		{
			part.gameObject.SetActive(isActive);
		}
	}

	private void AddExplosionForceToParts()
	{
		foreach (var part in _pinataParts)
		{
			part.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 0.1f, ForceMode2D.Impulse);
		}
	}

	[ContextMenu("ResetPosition")]
	private void ResetPosition()
	{
		_pinata.enabled = true;
		ResetPinataPartsPositions();
	}

	private void ResetPinataPartsPositions()
	{
		SetActiveExplodingParts(false);
		for (int i = 0; i < _pinataPartsPositions.Count; i++)
		{
			_pinataParts[i].position = _pinataPartsPositions[i];
		}
	}
}
