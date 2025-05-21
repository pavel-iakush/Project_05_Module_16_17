using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Choose behaviour for each state")]
    [SerializeField] private IdleStates _idleState;
    [SerializeField] private AgroStates _agroState;

    public IdleStates IdleState => _idleState;
    public AgroStates AgroState => _agroState;
}