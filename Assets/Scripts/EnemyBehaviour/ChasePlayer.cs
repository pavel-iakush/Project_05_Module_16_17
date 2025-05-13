using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChasePlayer : IAgroBehaviour
{
    private Enemy _enemy;
    private Player _player;

    private float _chaseRadius = 3.0f;

    public ChasePlayer(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Update(float deltaTime)
    {
        Vector3 direction = _enemy.transform.position - _player.transform.position;
        float distance = direction.magnitude;

        if (distance < _chaseRadius)
            Debug.Log("Start chase logic");
    }
}
