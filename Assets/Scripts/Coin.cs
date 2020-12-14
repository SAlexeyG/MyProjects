using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private GameObject coinGrapgics;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerInput>())
		{
			particleSystem.Play();
			gameManager.Coins++;
			Destroy(coinGrapgics);
		}
	}
}
