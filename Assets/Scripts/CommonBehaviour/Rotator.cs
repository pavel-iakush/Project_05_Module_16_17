using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _rotateSpeed;

    public void Initialize(float angle)
    {
        _rotateSpeed = angle;
    }

    public void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}