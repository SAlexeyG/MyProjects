using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	[SerializeField] private Transform[] points;
	[SerializeField] private float speed;
	[SerializeField] private float rotationLerp;
	[SerializeField] private GameManager gameManager;

	public float Speed { get => speed; set => speed = value; }
	int pointIndex = 2;

	void Update()
	{
		if (gameManager.playerState == PlayerState.Stop) return;
		if (pointIndex == points.Length - 1) return;

		if (Vector3.Distance(transform.position, points[pointIndex].position) < 0.1f) pointIndex++;

		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(points[pointIndex].position-transform.position), rotationLerp);
		transform.Translate((points[pointIndex].position - transform.position).normalized * speed * Time.deltaTime, Space.World);
	}
}
