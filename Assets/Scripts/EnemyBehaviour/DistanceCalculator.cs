using UnityEngine;

public class DistanceCalculator
{
    private readonly Transform _source;
    private Vector3 _currentTarget;

    public DistanceCalculator(Transform source, Vector3 currentTarget)
    {
        _source = source;
        _currentTarget = currentTarget;
    }

    public void UpdateTarget(Vector3 newTarget)
    {
        _currentTarget = newTarget;
    }

    public Vector3 GetCurrentTarget() => _currentTarget;

    public float GetDistance()
    {
        return Vector3.Distance(_source.position, _currentTarget);
    }

    public Vector3 GetDirectionNormalized()
    {
        return (_source.position - _currentTarget).normalized;
    }
}