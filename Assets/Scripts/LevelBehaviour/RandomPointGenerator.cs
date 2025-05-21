using UnityEngine;

public class RandomPointGenerator
{
    public Vector3 ChooseTarget()
    {
        int randomX = Random.Range(-8, 9);
        int randomZ = Random.Range(-6, 7);

        Vector3 currentRandomPoint = new Vector3(randomX, 0, randomZ);

        return currentRandomPoint;
    }
}