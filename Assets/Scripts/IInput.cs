using System;

public interface IInput
{
	event Action OnLeft;
	event Action OnRight;
	event Action OnUp;
	event Action OnDown;

	bool IsEnabled { get; set; }
}
