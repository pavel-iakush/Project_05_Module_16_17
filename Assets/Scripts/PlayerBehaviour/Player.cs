using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotator _rotator;

    private float _moveSpeed = 10.0f;
    private float _rotateSpeed = 750.0f;

    private string _xAxisName = "Horizontal";
    private string _zAxisName = "Vertical";
    private float _deadZone = 0.1f;

    private void Awake()
    {
        _mover.Initialize(_moveSpeed);
        _rotator.Initialize(_rotateSpeed);
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(_xAxisName), 0, Input.GetAxisRaw(_zAxisName));

        if (input.magnitude <= _deadZone)
        {
            return;
        }
        else
        {
            Vector3 NormalizedInput = input.normalized;

            _mover.ProcessMoveTo(NormalizedInput);
            _rotator.ProcessRotateTo(NormalizedInput);
        }
    }
}