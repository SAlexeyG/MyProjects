using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct UIComponents
{
	public TMP_Text scoreText;
	public TMP_Text linesText;
	public TMP_Text levelText;
	public Button pauseButton;
	public Button resumeButton;
	public GameObject panel;
}

public class UIManager : IUI
{
	private UIComponents components;

	public event Action OnPause;
	public event Action OnResume;

	public UIManager(UIComponents _components)
	{
		components = _components;

		components.pauseButton.onClick.AddListener(() =>
		{
			OnPause?.Invoke();
			components.panel.SetActive(true);
		});

		components.resumeButton.onClick.AddListener(() =>
		{
			OnResume?.Invoke();
			components.panel.SetActive(false);
		});
	}

	public void AddLine()
	{
		components.linesText.text = (Convert.ToInt32(components.linesText.text) + 1).ToString();
	}

	public void AddScore(int score)
	{
		components.scoreText.text = (Convert.ToInt32(components.scoreText.text) + score).ToString();
	}
}
