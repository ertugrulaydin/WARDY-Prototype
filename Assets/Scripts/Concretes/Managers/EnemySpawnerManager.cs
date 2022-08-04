using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] List<GameObject> _enemies;

    private List<float> _spawnPoints = new List<float>();

    private float _distance = 30f;

    private Vector3 _spawnerPosition = new Vector3(0, 0, 0);


    void Start()
    {


        for (float i = 4.5f; i >= -4.5; i -= 0.5f)
        {
            _spawnPoints.Add(i);
        }

        /*
        foreach (var item in _spawnPoints)
        {
            Debug.Log(item);
        }
        */

    }


    void FixedUpdate()
    {
        SpawnerPosition();
    }

    private void SpawnerPosition()
    {

        _spawnerPosition = new Vector3(_playerTransform.position.x + _distance, 0, 0);
        transform.position = _spawnerPosition;

    }
}
