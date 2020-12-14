using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private Transform[] pointsBezie;
	[SerializeField] private float step;

	void Start()
	{
		var line = GetComponent<LineRenderer>();

		Vector3[] points = new Vector3[transform.childCount];
		line.positionCount = points.Length;

		for (int i = 0; i < points.Length; i++)
			points[i] = transform.GetChild(i).position;

		line.SetPositions(points);
	}

#if UNITY_EDITOR

	Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) =>
		Mathf.Pow(1f - t, 3f) * p0 + 3f * Mathf.Pow(1f - t, 2f) * t * p1 + 3f * (1f - t) * Mathf.Pow(t, 2f) * p2 + Mathf.Pow(t, 3f) * p3;

	[ContextMenu("Generate points")]
	void GeneratePoints()
	{
		if((pointsBezie.Length - 1) % 3 != 0) return;

		for (int i = 0; i < pointsBezie.Length - 1; i += 3)
		{
			for(float t = 0; t < 1f; t += step)
			{
				GameObject point = new GameObject("Point");
				point.transform.position = GetPoint(pointsBezie[i].position, pointsBezie[i + 1].position, pointsBezie[i + 2].position, pointsBezie[i + 3].position, t);
				point.transform.parent = transform;
			}
		}

		GameObject p = new GameObject("Point");

		p.transform.position = GetPoint(
			pointsBezie[pointsBezie.Length - 4].position, 
			pointsBezie[pointsBezie.Length - 3].position, 
			pointsBezie[pointsBezie.Length - 2].position, 
			pointsBezie[pointsBezie.Length - 1].position, 
			1f);

		p.transform.parent = transform;
	}

	private void OnDrawGizmos()
	{
		if (pointsBezie.Length == 0) return;
		if ((pointsBezie.Length - 1) % 3 != 0) return;

		int segNumber = 20;
		Vector3 prevPoint = pointsBezie[0].position;

		for (int i = 0; i < pointsBezie.Length - 1; i += 3)
		{
			for (int j = 0; j < segNumber + 1; j++)
			{
				float param = (float)j / segNumber;
				Vector3 point = GetPoint(pointsBezie[i].position, pointsBezie[i + 1].position, pointsBezie[i + 2].position, pointsBezie[i + 3].position, param);
				Gizmos.DrawLine(prevPoint, point);
				prevPoint = point;
			}
		}
	}

#endif
}
