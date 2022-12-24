using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _intro;

	private void Start()
	{
		_intro.Play();
	}
}
