using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TetrominoSpawner : ITetrominoSpawner
{
	private Vector3 spawnPoint;
	private GameObject[] tetrominoVariants;
	private IInput inputManager;
	private List<Tetromino> tetrominos = new List<Tetromino>();
	private List<GameObject> tetrominoObjects = new List<GameObject>();

	public TetrominoSpawner(Vector3 _spawnPoint, GameObject[] _tetrominoVariants, IInput _inputManager)
	{
		spawnPoint = _spawnPoint;
		tetrominoVariants = _tetrominoVariants;
		inputManager = _inputManager;
	}

	public GameObject Create()
	{
		GameObject randomTerominoVariant = tetrominoVariants[Random.Range(0, tetrominoVariants.Length)];
		GameObject obj = GameObject.Instantiate(randomTerominoVariant,
					spawnPoint,
					Quaternion.identity);
		tetrominoObjects.Add(obj);
		return obj;
	}

	public void CreateTetrominoForField(IField field)
	{
		GameObject obj = Create();
		tetrominos.Add(new Tetromino(obj.transform, inputManager, field));
	}

	public void Delete(GameObject gameObject)
	{
		GameObject.Destroy(gameObject);
	}

	public void DisableTetromino(Tetromino tetromino)
	{
		tetromino.IsMoving = false;
		tetrominos.Remove(tetromino);

		IEnumerable<GameObject> objectsToRemove = tetrominoObjects.Where(o => o.transform.childCount == 0);

		foreach (GameObject obj in objectsToRemove)
			Delete(obj);

		tetrominoObjects.RemoveAll(o => o.transform.childCount == 0);
	}
}
