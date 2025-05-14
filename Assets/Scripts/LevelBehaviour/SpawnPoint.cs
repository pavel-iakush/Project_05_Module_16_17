using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyIdleStates _enemyIdleState;
    [SerializeField] private EnemyAgroStates _enemyAgroStates;

    private Player _player;
    [SerializeField] private Enemy _enemyPrefab;

    private Enemy _currentEnemy;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _currentEnemy = Instantiate(_enemyPrefab, gameObject.transform);

        int enemyBeh = (int)_enemyAgroStates;

        SpawnWith((EnemyAgroStates)enemyBeh);

        /*if (_enemyAgroStates.Equals(0))
        {
            RunAway runAway = new RunAway(_currentEnemy, _player);
            _currentEnemy.Initialize(runAway);
        }

        if (_enemyAgroStates.Equals(1))
        {
            ChasePlayer chasePlayer = new ChasePlayer(_currentEnemy, _player);
            _currentEnemy.Initialize(chasePlayer);
        }

        if (_enemyAgroStates.Equals(2))
        {
            ScareAndDie scareAndDie = new ScareAndDie(_currentEnemy, _player);
            _currentEnemy.Initialize(scareAndDie);
        }*/

        /*ChasePlayer chasePlayer = new ChasePlayer(enemy, _player);
        enemy.Initialize(chasePlayer);

        RunAway runAway = new RunAway(enemy, _player);
        enemy.Initialize(runAway);

        ScareAndDie scareAndDie = new ScareAndDie(enemy, _player);
        enemy.Initialize(scareAndDie);*/
    }

    private void SpawnWith(EnemyAgroStates enemyAgroState)
    {
        switch (enemyAgroState)
        {
            case EnemyAgroStates.RunAway:
                RunAway runAway = new RunAway(_currentEnemy, _player);
                _currentEnemy.Initialize(runAway);
                break;

            case EnemyAgroStates.ChasePlayer:
                ChasePlayer chasePlayer = new ChasePlayer(_currentEnemy, _player);
                _currentEnemy.Initialize(chasePlayer);
                break;

            case EnemyAgroStates.ScareAndDie:
                ScareAndDie scareAndDie = new ScareAndDie(_currentEnemy, _player);
                _currentEnemy.Initialize(scareAndDie);
                break;

            default:
                Debug.Log("Spawn type is not supported");
                break;
        }
    }
}