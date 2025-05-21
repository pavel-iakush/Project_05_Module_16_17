public class RunAway : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private Mover _mover;

    private float _runAwayRadius = 3.0f;
    private float _runAwaySpeed = 3.0f;

    public RunAway(DistanceCalculator distanceCalculator, Mover mover)
    {
        _distanceCalculator = distanceCalculator;
        _mover = mover;
    }

    public void Update()
    {
        float distance = _distanceCalculator.GetDistance();

        if (distance < _runAwayRadius)
            _mover.ProcessMoveTo(_distanceCalculator.GetDirectionNormalized(), _runAwaySpeed);
    }
}