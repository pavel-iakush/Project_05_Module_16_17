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
        Enemy enemy = Instantiate(_enemyPrefab, gameObject.transform);

        /*ChasePlayer chasePlayer = new ChasePlayer(enemy, _player);
        enemy.Initialize(chasePlayer);*/

        /*RunAway runAway = new RunAway(enemy, _player);
        enemy.Initialize(runAway);*/

        ScareAndDie scareAndDie = new ScareAndDie(enemy, _player);
        enemy.Initialize(scareAndDie);
    }
}
