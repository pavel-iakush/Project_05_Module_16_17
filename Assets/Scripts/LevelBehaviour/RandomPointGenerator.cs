using UnityEngine;

public class RandomPointGenerator
{
    private Vector3 _currentRandomPoint;

    public Vector3 CurrentRandomPoint => _currentRandomPoint;

    public Vector3 ChooseTarget()
    {
        int randomX = Random.Range(-8, 9);
        int randomZ = Random.Range(-6, 7);

        return _currentRandomPoint = new Vector3(randomX, 0, randomZ);
    }
}