using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Text text;

	private void Start()
	{
		text.text = PlayerPrefs.GetInt("Coins").ToString();
	}

	public void Play()
	{
		if (!PlayerPrefs.HasKey("Level")) PlayerPrefs.SetInt("Level", 1);
		SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void ResetProgress()
	{
		PlayerPrefs.DeleteAll();
	}

	public void Market()
	{
		SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
	}
}
