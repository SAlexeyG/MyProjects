using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUI
{
	event Action OnPause;
	event Action OnResume;
	void AddScore(int score);
	void AddLine();
}
