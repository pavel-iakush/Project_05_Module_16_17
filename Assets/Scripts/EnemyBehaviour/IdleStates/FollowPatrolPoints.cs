using System.Collections.Generic;
using UnityEngine;

public class FollowPatrolPoints : IIdleBehaviour
{
    private List<PatrolPoint> _patrolPoints;
    private Queue<Vector3> _pointPositions;
    private Vector3 _currentPoint;

    private Enemy _enemy;

    private float _patrolSpeed = 2.0f;
    private float _deadZone = 0.1f;

    public FollowPatrolPoints(List<PatrolPoint> patrolPoint, Enemy enemy)
    {
        _patrolPoints = patrolPoint;
        _enemy = enemy;
        _pointPositions = new Queue<Vector3>();

        foreach (PatrolPoint point in _patrolPoints)
            _pointPositions.Enqueue(point.transform.position);

        SwitchPatrolPoint();
    }

    public void UpdateIdle(float deltaTime)
    {
        Vector3 direction = _currentPoint - _enemy.transform.position;

        if (HasReachedPoint(direction))
            SwitchPatrolPoint();

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection, deltaTime);
    }

    private void SwitchPatrolPoint()
    {
        _currentPoint = _pointPositions.Dequeue();
        _pointPositions.Enqueue(_currentPoint);
    }

    private void ProcessMoveTo(Vector3 direction, float deltaTime)
        => _enemy.transform.Translate(direction * _patrolSpeed * deltaTime, Space.World);

    private bool HasReachedPoint(Vector3 direction)
        => direction.magnitude <= _deadZone;
}