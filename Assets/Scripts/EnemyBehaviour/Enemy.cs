using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Mover Mover;
    public Transform PlayerTransform { get; set; }
    public DistanceCalculator DistanceCalculator { get; set; }

    private IBehaviour _idleBehaviour;
    private IBehaviour _agroBehaviour;
    private IBehaviour _currentBehaviour;

    private float _detectRadius = 3.0f;

    private void Update()
    {
        _currentBehaviour.Update();
        UpdateBehaviourState();
    }

    private void UpdateBehaviourState()
    {
        DistanceCalculator.UpdateTarget(PlayerTransform.position);

        float distanceToPlayer = DistanceCalculator.GetDistance();

        if (distanceToPlayer <= _detectRadius)
        {
            SwitchToAgro();
        }
        else
        {
            SwitchToIdle();
        }
    }

    public void Initialize(IBehaviour idleBehaviour, IBehaviour agroBehaviour, Transform target, DistanceCalculator distanceCalculator)
    {
        _idleBehaviour = idleBehaviour;
        _agroBehaviour = agroBehaviour;
        PlayerTransform = target;
        DistanceCalculator = distanceCalculator;
        _currentBehaviour = _idleBehaviour;
    }

    public void SwitchToAgro()
    {
        if (_currentBehaviour == _agroBehaviour) return;
        _currentBehaviour = _agroBehaviour;
    }

    public void SwitchToIdle()
    {
        if (_currentBehaviour == _idleBehaviour) return;
        _currentBehaviour = _idleBehaviour;
    }
}