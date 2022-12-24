using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PinataParticleSystemManager : MonoBehaviour
{

	[SerializeField] private ParticleSystem _damageParticles;
	[SerializeField] private ParticleSystem _baseRewardParticles;
	[SerializeField] private ParticleSystem _baseRewardParticlesForeground;
		[SerializeField] private ParticleSystem _reward2Particles;
	[SerializeField] private ParticleSystem _reward3Particles;

	public void OnPinataDamaged(int damageRange)
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

		_baseRewardParticlesForeground.Play(true);
		_baseRewardParticles.Play(true);
		_damageParticles.Play(true);
	}

	private void HandleDamageRange(int damageRange)
	{
		var emission = _baseRewardParticles.emission;
		emission.SetBurst(0, new ParticleSystem.Burst(0f, (short) (30 * damageRange), (short) (30 * damageRange), 1, 0.01f));
	}

	private void StopAllParticles()
	{
		_damageParticles.Stop(true);
		_baseRewardParticles.Stop(true);
		_reward2Particles.Stop(true);
		_reward3Particles.Stop(true);
		_baseRewardParticlesForeground.Stop(true);
	}
}
