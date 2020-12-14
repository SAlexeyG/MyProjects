using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITetrominoSpawner : ISpawner
{
	void CreateTetrominoForField(IField field);
	void DisableTetromino(Tetromino tetromino);
}
