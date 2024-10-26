using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private Transform _spawnPositions;

	private List<Transform> _spawnPositionsList = new List<Transform>();
	private int _currentPositionIndex = 1;

	private void Awake()
	{
		FillTransformPositions();

		while (TryGetSpawnPoint(out Transform spawnPoint))
			Instantiate(_prefab, spawnPoint);
	}

	private bool TryGetSpawnPoint(out Transform spawnPoint)
	{
		spawnPoint = null;

		if (_currentPositionIndex == _spawnPositionsList.Count)
			return false;

		spawnPoint = _spawnPositionsList[_currentPositionIndex];
		_currentPositionIndex++;
		return true;
	}

	private void FillTransformPositions()
	{
		foreach (Transform spawnPoint in _spawnPositions.GetComponentsInChildren<Transform>())
			_spawnPositionsList.Add(spawnPoint);
	}
}
