using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
	GameObject Create();
	void Delete(GameObject gameObject);
}
