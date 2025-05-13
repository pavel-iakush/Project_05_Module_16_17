using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyIdleStates _enemyIdleState;
    [SerializeField] private EnemyAgroStates _enemyAgroStates;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemyPrefab;

    private void Awake()
    {
        Enemy enemy = Instantiate(_enemyPrefab);

        ChasePlayer chasePlayer = new ChasePlayer(enemy, _player);
        enemy.Initialize(chasePlayer);
    }
}
