public static class GeneralEventsDispatcher
{
	public delegate void TapPinataEvent();
	public static event TapPinataEvent PinataTapped;
	public delegate void PinataDamagedEvent();
	public static event PinataDamagedEvent PinataDamaged;
	
	public static void DispatchPinataTappedEvent()
	{
		PinataTapped?.Invoke();
	}

	public static void DispatchPinataDamagedEvent(int getDamageRange)
	{
		PinataDamaged?.Invoke();
	}
}
