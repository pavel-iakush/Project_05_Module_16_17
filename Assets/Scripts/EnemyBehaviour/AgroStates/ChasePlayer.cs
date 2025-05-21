public class ChasePlayer : IBehaviour
{
    private DistanceCalculator _distanceCalculator;
    private Mover _mover; 

    private float _chaseRadius = 4.0f;
    private float _chaseSpeed = 3.5f;

    public ChasePlayer(DistanceCalculator distanceCalculator, Mover mover)
    {
        _distanceCalculator = distanceCalculator;
        _mover = mover;
    }

    public void Update()
    {
        float distance = _distanceCalculator.GetDistance();

        if (distance < _chaseRadius)
            _mover.ProcessMoveTo(-_distanceCalculator.GetDirectionNormalized(), _chaseSpeed);
    }
}