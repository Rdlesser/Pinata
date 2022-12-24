﻿using System;
using UnityEngine;

public class PinataAnimationController : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	
	private static readonly int Hit = Animator.StringToHash("Hit");

	public void OnPinataDamaged(int damageRange)
	{
		_animator.SetTrigger(Hit);
	}
}
