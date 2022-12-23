using System;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	public Action ClickAction;
	
	public void OnMouseDown()
	{
		ClickAction?.Invoke();
		GeneralEventsDispatcher.DispatchPinataTappedEvent();
	}
}
