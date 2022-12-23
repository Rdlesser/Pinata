using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PinataParticleSystemManager : MonoBehaviour
{

	[SerializeField] private ParticleSystem _damageParticles;
	[SerializeField] private ParticleSystem _baseRewardParticles;
	[SerializeField] private ParticleSystem _reward2Particles;
	[SerializeField] private ParticleSystem _reward3Particles;

	private void OnEnable()
	{
		RegisterToEvents();
	}

	private void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataDamaged += OnPinataDamaged;
	}

	private void OnPinataDamaged(int damageRange)
	{
		StopAllParticles();
		HandleDamageRange(damageRange);
		PlayParticles(damageRange);
	}

	private void PlayParticles(int damageRange)
	{
		if (damageRange == 3)
		{
			_reward3Particles.Play(true);
		}

		if (damageRange >= 2)
		{
			_reward2Particles.Play(true);
		}

		_baseRewardParticles.Play(true);
		_damageParticles.Play(true);
	}

	private void HandleDamageRange(int damageRange)
	{
		var emission = _baseRewardParticles.emission;
		emission.rateOverTime = 30f * damageRange;
	}

	private void StopAllParticles()
	{
		_damageParticles.Stop(true);
		_baseRewardParticles.Stop(true);
		_reward2Particles.Stop(true);
		_reward3Particles.Stop(true);
	}
}
