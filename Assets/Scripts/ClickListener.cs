using System;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	public Action ClickAction;

	private bool _isInteractable = true;
	
	public void RegisterToEvents()
	{
		GeneralEventsDispatcher.PinataDestroyed += Disable;
		GeneralEventsDispatcher.TimeIsUp += Disable;
	}

	private void Disable()
	{
		_isInteractable = false;
	}

	public void OnMouseDown()
	{
		if (!_isInteractable)
		{
			return;
		}
		
		ClickAction?.Invoke();
		GeneralEventsDispatcher.DispatchPinataTappedEvent();
	}
}
