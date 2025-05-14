using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    public List<PatrolPoint> PatrolPoints => _patrolPoints;
}