using System;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	[SerializeField] 
	
	public Action ClickAction;
	
	public void OnMouseDown()
	{
		ClickAction?.Invoke();
		GeneralEventsDispatcher.DispatchPinataTappedEvent();
	}
}
