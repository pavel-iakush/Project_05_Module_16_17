using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private EnemyIdleStates _enemyIdleStates;
    [SerializeField] private EnemyAgroStates _enemyAgroStates;
    [Header("")]
    [SerializeField] private Enemy _enemyPrefab;

    private Player _player;
    private Enemy _enemy;
    private PatrolRoute _patrolRoute;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _patrolRoute = GameObject.FindGameObjectWithTag("PatrolPoints").GetComponentInParent<PatrolRoute>();

        _enemy = Instantiate(_enemyPrefab, gameObject.transform);

        SpawnWithAgro(_enemyAgroStates);
        SpawnWithIdle(_enemyIdleStates);
    }

    private void SpawnWithAgro(EnemyAgroStates enemyAgroState)
    {
        switch (enemyAgroState)
        {
            case EnemyAgroStates.RunAway:
                RunAway runAway = new RunAway(_enemy, _player);
                _enemy.SetAgroBehaviourTo(runAway);
                break;

            case EnemyAgroStates.ChasePlayer:
                ChasePlayer chasePlayer = new ChasePlayer(_enemy, _player);
                _enemy.SetAgroBehaviourTo(chasePlayer);
                break;

            case EnemyAgroStates.ScareAndDie:
                ScareAndDie scareAndDie = new ScareAndDie(_enemy, _player);
                _enemy.SetAgroBehaviourTo(scareAndDie);
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
                _enemy.SetIdleBehaviourTo(doNothing);
                break;

            case EnemyIdleStates.FollowPatrolPoints:
                FollowPatrolPoints followPatrolPoints = new FollowPatrolPoints(_patrolRoute.PatrolPoints, _enemy);
                _enemy.SetIdleBehaviourTo(followPatrolPoints);
                break;

            case EnemyIdleStates.RandomPatrol:
                RandomPatrol randomPatrol = new RandomPatrol(_enemy);
                _enemy.SetIdleBehaviourTo(randomPatrol);
                break;

            default:
                Debug.Log("Spawn type is not supported");
                break;
        }
    }
}