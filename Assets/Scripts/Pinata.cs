using System;
using UnityEngine;

public class Pinata : MonoBehaviour
{
    [SerializeField] private ClickListener _clickListener;
    [SerializeField] private ForceApplier _forceApplier;
    [SerializeField] private PinataAnimationController _animationController;
    [SerializeField] private PinataParticleSystemManager _particleSystemManager;

    private void OnEnable()
    {
        RegisterClickListenerEvents();
        RegisterForceApplierEvents();
        RegisterAnimationControllerEvents();
        RegisterParticleSystemManagerEvents();
    }

    private void RegisterClickListenerEvents()
    {
        _clickListener.RegisterToEvents();
    }

    private void RegisterParticleSystemManagerEvents()
    {
        _clickListener.ClickAction += _particleSystemManager.OnPinataHit;
        GeneralEventsDispatcher.PinataDestroyed += _particleSystemManager.OnPinataDestroyed;
    }

    private void UnregisterParticleSystemManagerEvents()
    {
        _clickListener.ClickAction -= _particleSystemManager.OnPinataHit;
        GeneralEventsDispatcher.PinataDestroyed -= _particleSystemManager.OnPinataDestroyed;
    }

    private void RegisterAnimationControllerEvents()
    {
        _clickListener.ClickAction += _animationController.OnPinataDamaged;
    }

    private void UnregisterAnimationControllerEvents()
    {
        _clickListener.ClickAction -= _animationController.OnPinataDamaged;
    }

    private void RegisterForceApplierEvents()
    {
        _clickListener.ClickAction += _forceApplier.ApplyRandomForce;
    }

    private void UnregisterForceApplierEvents()
    {
        _clickListener.ClickAction -= _forceApplier.ApplyRandomForce; 
    }

    private void OnDisable()
    {
        UnregisterAllEvents();
    }

    private void UnregisterAllEvents()
    {
        UnregisterAnimationControllerEvents();
        UnregisterForceApplierEvents();
        UnregisterParticleSystemManagerEvents();
    }
}
