using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Finish : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;

	[SerializeField] private GameObject winPanel;
	[SerializeField] private Text score;

	[SerializeField] private ParticleSystem[] particles;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerInput>())
		{
			gameManager.playerState = PlayerState.Stop;
			winPanel.SetActive(true);

			foreach (var particle in particles)
				particle.Play();

			score.text = gameManager.Score.ToString();

			PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
			PlayerPrefs.SetInt("Coins", gameManager.Coins);
		}
	}
}
