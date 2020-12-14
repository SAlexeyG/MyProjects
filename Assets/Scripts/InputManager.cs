using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : ITickable, IInput
{
	private float fallTime;
	public bool IsEnabled { get; set; }

	public InputManager(float _fallTime)
	{
		IsEnabled = true;
		fallTime = _fallTime;
	}

	public event Action OnLeft;
	public event Action OnRight;
	public event Action OnUp;
	public event Action OnDown;

	private float previousTime;

	public void Tick()
	{
		if (IsEnabled)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow)) OnLeft?.Invoke();
			if (Input.GetKeyDown(KeyCode.RightArrow)) OnRight?.Invoke();
			if (Input.GetKeyDown(KeyCode.UpArrow)) OnUp?.Invoke();

			if (Time.time - previousTime >
				(Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
			{
				OnDown?.Invoke();
				previousTime = Time.time;
			}
		}
	}
}
