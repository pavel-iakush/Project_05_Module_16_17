using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IAgroBehaviour _agroBehaviour;

    public void Initialize(IAgroBehaviour agroBehaviour)
    {
        _agroBehaviour = agroBehaviour;
    }

    private void Update()
    {
        _agroBehaviour.Update(Time.deltaTime);
    }
}
