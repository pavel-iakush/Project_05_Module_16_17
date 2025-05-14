using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private EnemyIdleStates _enemyIdleStates;
    [SerializeField] private EnemyAgroStates _enemyAgroStates;
    [Header("monobehi")]
    [SerializeField] private Enemy _enemyPrefab;

    private Player _player;
    private Enemy _currentEnemy;
    private PatrolRoute _patrolRoute;

    private void Awake()
    {
        _player = FindObjectOfType<Player>(); //заменить!
        _patrolRoute = FindObjectOfType<PatrolRoute>(); //заменить!

        _currentEnemy = Instantiate(_enemyPrefab, gameObject.transform);

        SpawnWithAgro(_enemyAgroStates);
        SpawnWithIdle(_enemyIdleStates);
    }

    private void SpawnWithAgro(EnemyAgroStates enemyAgroState)
    {
        switch (enemyAgroState)
        {
            case EnemyAgroStates.RunAway:
                RunAway runAway = new RunAway(_currentEnemy, _player);
                _currentEnemy.SetAgroBehaviourTo(runAway);
                break;

            case EnemyAgroStates.ChasePlayer:
                ChasePlayer chasePlayer = new ChasePlayer(_currentEnemy, _player);
                _currentEnemy.SetAgroBehaviourTo(chasePlayer);
                break;

            case EnemyAgroStates.ScareAndDie:
                ScareAndDie scareAndDie = new ScareAndDie(_currentEnemy, _player);
                _currentEnemy.SetAgroBehaviourTo(scareAndDie);
                break;

            default:
                Debug.Log("Spawn type is not supported");
                break;
        }
    }

    private void SpawnWithIdle(EnemyIdleStates enemyIdleState)
    {
        switch (enemyIdleState)
        {
            case EnemyIdleStates.DoNothing:
                DoNothing doNothing = new DoNothing();
                _currentEnemy.SetIdleBehaviourTo(doNothing);
                break;

            case EnemyIdleStates.FollowPatrolPoints:
                FollowPatrolPoints followPatrolPoints = new FollowPatrolPoints(_patrolRoute.PatrolPoints, _currentEnemy);
                _currentEnemy.SetIdleBehaviourTo(followPatrolPoints);
                break;

            case EnemyIdleStates.RandomPatrol:
                //logic
                break;

            default:
                Debug.Log("Spawn type is not supported");
                break;
        }
    }
}