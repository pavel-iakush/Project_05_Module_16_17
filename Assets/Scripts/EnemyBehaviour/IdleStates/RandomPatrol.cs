using UnityEngine;

public class RandomPatrol : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private RandomPointGenerator _randomPointGenerator;
    private Mover _mover;

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
        if (_distanceCalculator.GetDistance() <= _deadZone)
        {
            UpdateTargetPosition();
        }

        Vector3 direction = _distanceCalculator.GetDirectionNormalized();
        _mover.ProcessMoveTo(-direction, _patrolSpeed);
    }

    private void UpdateTargetPosition()
    {
        Vector3 newTarget = _randomPointGenerator.ChooseTarget();
        _distanceCalculator.UpdateTarget(newTarget);
        Debug.Log($"New patrol target: {newTarget}");
    }
}