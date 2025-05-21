using System.Collections.Generic;
using UnityEngine;

public class FollowPatrolPoints : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private Mover _mover;

    private Queue<Vector3> _pointPositions = new Queue<Vector3>();
    private Vector3 _currentPoint;

    private float _patrolSpeed = 2.0f;
    private float _deadZone = 0.1f;

    public FollowPatrolPoints(DistanceCalculator distanceCalculator, List<PatrolPoint> patrolPoint, Mover mover)
    {
        _distanceCalculator = distanceCalculator;
        _mover = mover;

        foreach (PatrolPoint point in patrolPoint)
            _pointPositions.Enqueue(point.transform.position);

        SwitchPatrolPoint();
    }

    public void Update()
    {
        float distanceToTarget = _distanceCalculator.GetDistance();

        if (distanceToTarget <= _deadZone)
            SwitchPatrolPoint();

        Vector3 directionNormalized = _distanceCalculator.GetDirectionNormalized();
        _mover.ProcessMoveTo(-directionNormalized, _patrolSpeed);
    }

    private void SwitchPatrolPoint()
    {
        _currentPoint = _pointPositions.Dequeue();
        _pointPositions.Enqueue(_currentPoint);

        _distanceCalculator.UpdateTarget(_currentPoint);
    }
}