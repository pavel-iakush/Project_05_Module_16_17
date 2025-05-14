using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChasePlayer : IAgroBehaviour
{
    private Enemy _enemy;
    private Player _player;

    private float _chaseRadius = 4.0f;
    private float _chaseSpeed = 3.5f;

    public ChasePlayer(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void UpdateAgro(float deltaTime)
    {
        Vector3 direction = _player.transform.position - _enemy.transform.position;
        Vector3 normalizedDirection = direction.normalized;
        float distance = direction.magnitude;

        if (distance < _chaseRadius)
            _enemy.transform.Translate(normalizedDirection * _chaseSpeed * Time.deltaTime);
    }
}
