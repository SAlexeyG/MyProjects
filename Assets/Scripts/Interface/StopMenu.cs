using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{
	[SerializeField] private GameObject panel;

    public void Pause()
	{
		Time.timeScale = 0f;
		panel.SetActive(true);
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		panel.SetActive(false);
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Exit()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
