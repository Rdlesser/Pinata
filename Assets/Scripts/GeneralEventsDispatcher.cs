public static class GeneralEventsDispatcher
{
	public delegate void TapPinataEvent();
	public static event TapPinataEvent PinataTapped;
	public delegate void PinataDamagedEvent(int damageRange);
	public static event PinataDamagedEvent PinataDamaged;

	public delegate void PinataDestroyedEvent();
	public static event PinataDestroyedEvent PinataDestroyed;

	public delegate void GoldUpdatedValueEvent(int newValue);
	public static event GoldUpdatedValueEvent GoldUpdatedValue;
	
	public delegate void OneStarsReachedEvent();
	public static event OneStarsReachedEvent OneStarReached;
	public delegate void TwoStarsReachedEvent();
	public static event TwoStarsReachedEvent TwoStarsReached;
	public delegate void ThreeStarsReachedEvent();
	public static event ThreeStarsReachedEvent ThreeStarsReached;

	public delegate void TimeUpEvent();
	public static event TimeUpEvent TimeIsUp;

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

	public static void DispatchGoldUpdateValueEvent(int newValue)
	{
		GoldUpdatedValue?.Invoke(newValue);
	}

	public static void DispatchThreeStarsReached()
	{
		ThreeStarsReached?.Invoke();
	}
	public static void DispatchTwoStarsReached()
	{
		TwoStarsReached?.Invoke();
	}
	public static void DispatchOneStarReached()
	{
		OneStarReached?.Invoke();
	}

	public static void DispatchTimeIsUpEvent()
	{
		TimeIsUp?.Invoke();
	}
}
