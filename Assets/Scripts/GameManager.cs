using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum PlayerState
{
	Stop,
	Move, 
	Boost,

}

public class GameManager : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private Text coinsText;
	[SerializeField] private Text counterText;

	[SerializeField] private float boostRatio;
	[SerializeField] private float boostTime;

	[SerializeField] private PlayerScript player;
	[SerializeField] private TrailRenderer trail;
	[SerializeField] private ParticleSystem particles;

	private float floatScore = 0f;
	private Coroutine boostCoroutine; 

	public PlayerState playerState { get; set; }
	public int Score { get; set; }
	public int Coins { get; set; }
	public float Boost { get; set; }

	private IEnumerator Start()
	{
		playerState = PlayerState.Stop;
		Coins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt("Coins") : 0;

		yield return new WaitForSeconds(1f);
		counterText.text = "2";
		yield return new WaitForSeconds(1f);
		counterText.text = "1";
		yield return new WaitForSeconds(1f);
		counterText.text = "";

		playerState = PlayerState.Move;
	}

	void Update()
	{
		switch (playerState)
		{
			case PlayerState.Move:
				floatScore += Time.deltaTime;
				Score += (int)floatScore;
				floatScore -= (int)floatScore;
				if (Boost >= 1) playerState = PlayerState.Boost;
				break;

			case PlayerState.Boost:
				boostCoroutine = boostCoroutine ?? StartCoroutine(EnableBoost());
				Boost = 0;
				break;
		}

		coinsText.text = Coins.ToString();
		image.fillAmount = Mathf.Lerp(image.fillAmount, Boost, 0.06f);
		Boost -= 0.03f * Time.deltaTime;
	}

	private IEnumerator EnableBoost()
	{
		particles.Play();
		trail.enabled = true;
		player.Speed *= boostRatio;

		yield return new WaitForSeconds(boostTime);

		player.Speed /= boostRatio;
		trail.enabled = false;
		playerState = PlayerState.Move;
		boostCoroutine = null;
	}

}
