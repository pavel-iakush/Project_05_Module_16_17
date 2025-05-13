using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _value;
    private float _maxValue = 20.0f;
    private float _defaultValue = 10.0f;

    public float Value
    {   
        get
        {
            return _value;
        }
        set
        {
            float newValue = value;

            if (newValue > _maxValue)
                newValue = _maxValue;

            if (newValue == _value)
                return;

            _value = newValue;

            if (_value >= _maxValue)
                _value = _maxValue;

            if (_value < _defaultValue)
                _value = _defaultValue;
        }
    }

    public void Initialize(float speed)
    {
        _value = speed;
    }

    public void ProcessMoveTo(Vector3 direction)
        => transform.Translate(direction * _value * Time.deltaTime, Space.World);

    public void IncreaseSpeed(float amount)
    {
        Value = _value + amount;
    }
    
    public void DecreaseSpeed(float amount)
    {
        Value = _value - amount;
    }
}