using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;
    [SerializeField] private GameObject _prefabEnemy;
    private void OnEnable()
    {
        _enemy = FindObjectOfType<EnemyController>();
        _enemy.OnEnemyDead += SpawnEnemy;
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(_prefabEnemy, new Vector3(0, 1.5f, 30f), Quaternion.Euler(0,180,0));
        newEnemy.GetComponent<EnemyController>().EnemyStartRunning();
    }
}
