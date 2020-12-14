using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
	private IInput inputManager;
	private IField field;
	private IUI uiManager;

	private int score;

	public GameManager(IInput _input, IField _field, IUI _uiManager)
	{
		inputManager = _input;
		field = _field;
		uiManager = _uiManager;

		inputManager.OnDown += () => uiManager.AddScore(1);
		field.OnLineDeleted += uiManager.AddLine;
		field.OnOverflow += () => SceneManager.LoadScene(0);
		uiManager.OnPause += () => inputManager.IsEnabled = false;
		uiManager.OnResume += () => inputManager.IsEnabled = true;
	}
}
