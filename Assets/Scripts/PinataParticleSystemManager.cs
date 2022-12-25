using UnityEngine;

public class PinataParticleSystemManager : MonoBehaviour
{

	[SerializeField] private ParticleSystem _damageParticles;
	[SerializeField] private ParticleSystem _baseRewardParticles;
	[SerializeField] private ParticleSystem _baseRewardParticlesForeground;
	[SerializeField] private ParticleSystem _allGoldParticles;
	[SerializeField] private short _particleEmissionCount = 90;

	public void OnPinataHit()
	{
		StopAllParticles();
		HandleDamageRange();
		PlayParticles();
	}

	public void OnPinataDestroyed()
	{
		_allGoldParticles.Stop(true);
		_allGoldParticles.Play(true);
	}

	private void PlayParticles()
	{
		_baseRewardParticlesForeground.Play(true);
		_baseRewardParticles.Play(true);
		_damageParticles.Play(true);
	}

	private void HandleDamageRange()
	{
		var emission = _baseRewardParticles.emission;
		emission.SetBurst(0, new ParticleSystem.Burst(0f, _particleEmissionCount, _particleEmissionCount, 1, 0.01f));
	}

	private void StopAllParticles()
	{
		_damageParticles.Stop(true);
		_baseRewardParticles.Stop(true);
		_baseRewardParticlesForeground.Stop(true);
	}
}
