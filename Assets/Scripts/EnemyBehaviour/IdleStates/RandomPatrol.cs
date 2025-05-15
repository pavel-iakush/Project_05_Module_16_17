using UnityEngine;

public class RandomPatrol : IIdleBehaviour
{
    private Vector3 _targetPoint = Vector3.zero;

    private Enemy _enemy;

    private float _patrolSpeed = 2.0f;
    private float _deadZone = 0.1f;

    public RandomPatrol(Enemy enemy)
    {
        _enemy = enemy;

        ChooseTarget();
    }

    public void UpdateIdle(float deltaTime)
    {
        Vector3 direction = _targetPoint - _enemy.transform.position;

        if (direction.magnitude <= _deadZone)
            ChooseTarget();

        ProcessMoveTo(direction.normalized, deltaTime);
    }

    private void ChooseTarget()
    {
        _targetPoint.x = Random.Range(-8, 9);
        _targetPoint.z = Random.Range(-6, 7);
    }

    private void ProcessMoveTo(Vector3 direction, float deltaTime)
        => _enemy.transform.Translate(direction * _patrolSpeed * deltaTime, Space.World);
}