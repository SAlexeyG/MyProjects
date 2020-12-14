using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Obstacle : MonoBehaviour
{
	[SerializeField] private float minNecessaryScale = 0f;
	[SerializeField] private float maxNecessaryScale = 0f;

	[SerializeField] private GameManager gameManager;
	[SerializeField] private Transform playerSphere;

	[SerializeField] private Animator animator;
	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private GameObject loosePanel;

	[Header("For editor")]
	[SerializeField] private Transform point;
	[SerializeField] private Transform prevPoint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerInput>())
		{
			if ((other.gameObject.transform.localScale.x >= minNecessaryScale && other.gameObject.transform.localScale.x <= maxNecessaryScale) || gameManager.playerState == PlayerState.Boost)
			{
				gameManager.Boost += (gameManager.playerState == PlayerState.Boost) ? 0 : 0.3f;
				gameManager.Score += (maxNecessaryScale - other.gameObject.transform.localScale.x < 0.2f) ? 20 : 10;

				animator.SetTrigger("Overlap");
				particleSystem.Play();
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
			else
			{
				gameManager.playerState = PlayerState.Stop;
				loosePanel.SetActive(true);
				PlayerPrefs.SetInt("Coins", gameManager.Coins);
			}
		}
	}

	private void Update()
	{
		if (Vector3.Distance(transform.position, playerSphere.position) < 3f)
			GetComponent<SpriteRenderer>().color = 
				(playerSphere.localScale.x >= minNecessaryScale && playerSphere.localScale.x <= maxNecessaryScale) ? new Color(0, 1, 0, 0.2f) : new Color(1, 0, 0, 0.2f);
	}

#if UNITY_EDITOR

	[ContextMenu("Set obstacle")]
	void SetObstacle()
	{
		transform.position = point.position;
		transform.LookAt(prevPoint);
	}

#endif
}
