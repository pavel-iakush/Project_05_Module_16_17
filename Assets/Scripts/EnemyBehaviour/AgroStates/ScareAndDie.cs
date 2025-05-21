using UnityEngine;

public class ScareAndDie : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private GameObject _source;

    private float _scareRadius = 3.0f;

    public ScareAndDie(DistanceCalculator distanceCalculator, GameObject source)
    {
        _distanceCalculator = distanceCalculator;
        _source = source;
    }

    public void Update()
    {
        float distance = _distanceCalculator.GetDistance();

        if (distance < _scareRadius)
            Object.Destroy(_source.gameObject);
    }
}