using UnityEngine;

public class DoNothing : IIdleBehaviour
{
    public void UpdateIdle(float deltaTime)
    {
        return;
    }
}