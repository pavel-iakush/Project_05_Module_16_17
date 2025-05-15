using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _value;

    public void Initialize(float speed)
        => _value = speed;

    public void ProcessMoveTo(Vector3 direction)
        => transform.Translate(direction * _value * Time.deltaTime, Space.World);
}