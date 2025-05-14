using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IIdleBehaviour _idleBehaviour;
    private IAgroBehaviour _agroBehaviour;

    public void SetAgroBehaviourTo(IAgroBehaviour agroBehaviour)
        => _agroBehaviour = agroBehaviour;

    public void SetIdleBehaviourTo(IIdleBehaviour idleBehaviour)
        => _idleBehaviour = idleBehaviour;

    private void Update()
    {
        _agroBehaviour.UpdateAgro(Time.deltaTime);
        _idleBehaviour.UpdateIdle(Time.deltaTime);
    }
}