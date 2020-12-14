using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Tetromino
{
	private Transform transform;
	private IInput inputManager;
	private bool isMoving;
	private IField field;

	public Transform Transform => transform;

	public bool IsMoving
	{
		get => isMoving;
		set
		{
			isMoving = value;
			if (isMoving) EnableInput();
			else DisableInput();
		}
	}

	public Tetromino(Transform _transform, IInput _input, IField _field)
	{
		transform = _transform;
		inputManager = _input;
		field = _field;
		IsMoving = true;
	}

	private void EnableInput()
	{
		inputManager.OnLeft += MoveLeft;
		inputManager.OnRight += MoveRight;
		inputManager.OnUp += Rotate;
		inputManager.OnDown += Fall;
	}

	private void DisableInput()
	{
		inputManager.OnLeft -= MoveLeft;
		inputManager.OnRight -= MoveRight;
		inputManager.OnUp -= Rotate;
		inputManager.OnDown -= Fall;
	}

	private void Rotate()
	{
		transform.Rotate(Vector3.forward, -90f);
		if (!field.ValidatePosition(this))
			transform.Rotate(Vector3.forward, 90f);
	}

	private void Fall()
	{
		transform.position += Vector3.down;
		if (!field.ValidatePosition(this))
		{
			transform.position += Vector3.up;
			field.AddToGrid(this);
		}
	}

	private void MoveLeft()
	{
		Move(Vector3.left);
	}

	private void MoveRight()
	{
		Move(Vector3.right);
	}

	private void Move(Vector3 direction)
	{
		transform.position += direction;
		if (!field.ValidatePosition(this))
			transform.position -= direction;
	}
}
