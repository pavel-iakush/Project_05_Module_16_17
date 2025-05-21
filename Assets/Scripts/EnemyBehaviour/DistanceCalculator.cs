using UnityEngine;

public class DistanceCalculator
{
    private readonly Transform _source;
    private Vector3 _target;

    public DistanceCalculator(Transform source, Vector3 target)
    {
        _source = source;
        _target = target;
    }

    public void UpdateTarget(Vector3 newTarget)
    {
        _target = newTarget;
    }

    public Vector3 GetCurrentTarget()
        => _target;

    public float GetDistance()
    {
        return Vector3.Distance(_source.position, _target);
    }

    public Vector3 GetDirectionNormalized()
    {
        return (_source.position - _target).normalized;
    }
}