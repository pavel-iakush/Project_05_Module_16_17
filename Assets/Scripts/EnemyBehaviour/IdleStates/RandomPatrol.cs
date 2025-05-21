using UnityEngine;

public class RandomPatrol : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private Mover _mover;
    private RandomPointGenerator _randomPointGenerator;

    private float _patrolSpeed = 2.0f;
    private float _deadZone = 0.1f;

    public RandomPatrol(DistanceCalculator distanceCalculator, Mover mover, RandomPointGenerator randomPointGenerator)
    {
        _distanceCalculator = distanceCalculator;
        _mover = mover;
        _randomPointGenerator = randomPointGenerator;

        UpdateTargetPosition();
    }

    public void Update()
    {
        float distanceToTarget = _distanceCalculator.GetDistance();

        if (distanceToTarget <= _deadZone)
        {
            UpdateTargetPosition();
        }

        Vector3 directionNormalized = _distanceCalculator.GetDirectionNormalized();
        _mover.ProcessMoveTo(-directionNormalized, _patrolSpeed);
    }

    private void UpdateTargetPosition()
    {
        Vector3 newTarget = _randomPointGenerator.ChooseTarget();
        _distanceCalculator.UpdateTarget(newTarget);
    }
}