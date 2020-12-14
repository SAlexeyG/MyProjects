using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IField
{
	event Action OnOverflow;
	event Action OnLineDeleted;
	bool ValidatePosition(Tetromino tetromino);
	void AddToGrid(Tetromino tetromino);
}
