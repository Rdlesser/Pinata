using UnityEngine;

public class Pinata : MonoBehaviour
{
    [SerializeField] private ClickListener _clickListener;
    [SerializeField] private ForceApplier _forceApplier;

    private void OnEnable()
    {
        RegisterForceApplierEvents();
    }

    private void RegisterForceApplierEvents()
    {
        _clickListener.ClickAction += _forceApplier.ApplyRandomForce;
    }
}
