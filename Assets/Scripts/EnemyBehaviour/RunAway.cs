using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : IAgroBehaviour
{
    private Enemy _enemy;
    private Player _player;

    private float _runAwayRadius = 3.0f;
    private float _runAwaySpeed = 3.0f;

    public RunAway(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Update(float deltaTime)
    {
        Vector3 direction = _enemy.transform.position - _player.transform.position;
        Vector3 normalizedDirection = direction.normalized;
        float distance = direction.magnitude;

        if (distance < _runAwayRadius)
            _enemy.transform.Translate(normalizedDirection * _runAwaySpeed * Time.deltaTime);
    }
}
