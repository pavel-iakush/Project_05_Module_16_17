using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareAndDie : IAgroBehaviour
{
    private Enemy _enemy;
    private Player _player;

    private float _scareRadius = 3.0f;

    public ScareAndDie(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void UpdateAgro(float deltaTime)
    {
        Vector3 direction = _enemy.transform.position - _player.transform.position;
        float distance = direction.magnitude;

        if (distance < _scareRadius)
            Object.Destroy(_enemy.gameObject);
    }
}
