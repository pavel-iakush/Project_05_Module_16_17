using System.Collections.Generic;
using UnityEngine;

public class FollowPatrolPoints : IBehaviour
{
    private DistanceCalculator _distanceCalculator;

    private Queue<Vector3> _pointPositions = new Queue<Vector3>();
    private Vector3 _currentPoint;

    private Mover _mover;

    private float _patrolSpeed = 2.0f;
    private float _deadZone = 0.1f;

    public FollowPatrolPoints(DistanceCalculator distanceCalculator, List<PatrolPoint> patrolPoint, Mover mover)
    {
        _mover = mover;
        _distanceCalculator = distanceCalculator;

        foreach (PatrolPoint point in patrolPoint)
            _pointPositions.Enqueue(point.transform.position);

        SwitchPatrolPoint();
    }

    public void Update()
    {
        float distance = _distanceCalculator.GetDistance();

        if (distance <= _deadZone)
            SwitchPatrolPoint();

        _mover.ProcessMoveTo(-_distanceCalculator.GetDirectionNormalized(), _patrolSpeed);
    }

    private void SwitchPatrolPoint()
    {
        _currentPoint = _pointPositions.Dequeue();
        _pointPositions.Enqueue(_currentPoint);
    }
}