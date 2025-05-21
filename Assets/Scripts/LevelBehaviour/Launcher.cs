using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private PatrolRoute _patrolRoute;

    private Enemy _currentEnemy;
    private Player _currentPlayer;
    private DistanceCalculator _currentCalculator;
    private DistanceCalculator _randomPatrolCalculator;
    private DistanceCalculator _pointPatrolCalculator;
    private RandomPointGenerator _randomPointGenerator;
    private SpawnPoint[] _spawnPoints;

    void Start()
    {
        _currentPlayer = Instantiate(_playerPrefab);
        _randomPointGenerator = new RandomPointGenerator();

        GameObject[] spawnGameObject = GameObject.FindGameObjectsWithTag("SpawnPoint");
        _spawnPoints = new SpawnPoint[spawnGameObject.Length];

        for (int i = 0; i < spawnGameObject.Length; i++)
        {
            _spawnPoints[i] = spawnGameObject[i].GetComponent<SpawnPoint>(); ;
        }

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            _currentEnemy = Instantiate(_enemyPrefab, spawnPoint.transform);

            _randomPointGenerator = new RandomPointGenerator();
            _currentCalculator = new DistanceCalculator(_currentEnemy.transform, _currentPlayer.transform.position);
            _randomPatrolCalculator = new DistanceCalculator(_currentEnemy.transform, _randomPointGenerator.ChooseTarget());
            _pointPatrolCalculator = new DistanceCalculator(_currentEnemy.transform, _patrolRoute.PatrolPoints[0].transform.position);

            Mover mover = _currentEnemy.GetComponent<Mover>();

            _currentEnemy.Initialize(
                SetIdleState(
                    spawnPoint,
                    _randomPatrolCalculator,
                    _pointPatrolCalculator,
                    mover,
                    _patrolRoute.PatrolPoints,
                    _randomPointGenerator
                ),
                SetAgroState(
                    spawnPoint,
                    _currentCalculator,
                    mover
                ),
                _currentPlayer.transform,
                _currentCalculator
            );
        }
    }

    private IBehaviour SetIdleState(SpawnPoint spawnPoint, DistanceCalculator randomPointCalculator, DistanceCalculator pointPatrolCalculator, Mover mover, List<PatrolPoint> patrolPoints, RandomPointGenerator randomPointGenerator)
    {

        switch (spawnPoint.IdleState)
        {
            case IdleStates.DoNothing:
                return new DoNothing();

            case IdleStates.FollowPatrolPoints:
                return new FollowPatrolPoints(pointPatrolCalculator, patrolPoints, mover);

            case IdleStates.RandomPatrol:
                return new RandomPatrol(randomPointCalculator, mover, randomPointGenerator);

            default:
                Debug.Log("Spawn type is not supported");
                return new DoNothing();
        }
    }

    private IBehaviour SetAgroState(SpawnPoint spawnPoint, DistanceCalculator distanceCalculator, Mover mover)
    {

        switch (spawnPoint.AgroState)
        {
            case AgroStates.RunAway:
                return new RunAway(distanceCalculator, mover);

            case AgroStates.ChasePlayer:
                return new ChasePlayer(distanceCalculator, mover);

            case AgroStates.ScareAndDie:
                return new ScareAndDie(distanceCalculator, _currentEnemy.gameObject);

            default:
                Debug.Log("Spawn type is not supported");
                return new DoNothing();
        }
    }
}