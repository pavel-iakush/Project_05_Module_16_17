using UnityEngine;

public class Mover : MonoBehaviour
{
    public void ProcessMoveTo(Vector3 direction, float speed)
        => transform.Translate(direction * speed * Time.deltaTime, Space.World);
}