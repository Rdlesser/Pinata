using UnityEngine;

public class Pinata : MonoBehaviour
{
    [SerializeField] private ClickListener _clickListener;
    [SerializeField] private ForceApplier _forceApplier;
    [SerializeField] private PinataAnimationController _animationController;
    [SerializeField] private PinataParticleSystemManager _particleSystemManager;

    private void OnEnable()
    {
        RegisterForceApplierEvents();
        RegisterAnimationControllerEvents();
        RegisterParticleSystemManagerEvents();
    }

    private void RegisterParticleSystemManagerEvents()
    {
        GeneralEventsDispatcher.PinataDamaged += _particleSystemManager.OnPinataDamaged;
        GeneralEventsDispatcher.PinataDestroyed += _particleSystemManager.OnPinataDestroyed;
    }

    private void RegisterAnimationControllerEvents()
    {
        GeneralEventsDispatcher.PinataDamaged += _animationController.OnPinataDamaged;
    }

    private void RegisterForceApplierEvents()
    {
        _clickListener.ClickAction += _forceApplier.ApplyRandomForce;
    }
}
