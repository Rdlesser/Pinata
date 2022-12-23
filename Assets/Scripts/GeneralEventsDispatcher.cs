public static class GeneralEventsDispatcher
{
	public delegate void TapPinataEvent();
	public static event TapPinataEvent PinataTapped;
	public delegate void PinataDamagedEvent(int damageRange);
	public static event PinataDamagedEvent PinataDamaged;

	public delegate void PinataDestroyedEvent();
	public static event PinataDestroyedEvent PinataDestroyed;

	public static void DispatchPinataTappedEvent()
	{
		PinataTapped?.Invoke();
	}

	public static void DispatchPinataDamagedEvent(int damageRange)
	{
		PinataDamaged?.Invoke(damageRange);
	}

	public static void DispatchPinataDestroyedEvent()
	{
		PinataDestroyed?.Invoke();
	}
}
