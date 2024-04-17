using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPosition
{
    private float _spawnRadius;
    private Transform _spawnPoint;
    private Vector3 _randomSpawnPoint;
    public RandomSpawnPosition(Transform spawnPoint, float spawnRadius)
    {
        this._spawnPoint = spawnPoint;
        this._spawnRadius = spawnRadius;
    }

    public Vector3 GetRandomPosition()
    {
        _randomSpawnPoint = _spawnPoint.position + Random.insideUnitSphere * _spawnRadius;
        _randomSpawnPoint = new Vector3(_randomSpawnPoint.x, _spawnPoint.position.y, _randomSpawnPoint.z);
        return _randomSpawnPoint;
    }
}
