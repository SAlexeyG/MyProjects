using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	bool isPressed = false;
	Vector2 firstMousePosition;

	void Update()
	{
		if (!isPressed)
		{
			if (Input.GetMouseButton(0))
			{
				isPressed = true;
				firstMousePosition = Input.mousePosition;
			}
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				float scale = (Input.mousePosition.y - firstMousePosition.y) / (Screen.height * 8);
				scale += transform.localScale.y;
				scale = Mathf.Clamp(scale, 0.5f, 1.5f);
				transform.localScale = new Vector3(scale, scale, scale);
			}
			else isPressed = false;
		}
	}
}
