using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    private float _xBorder = 9.0f;
    private float _zUpperBorder = 5.8f;
    private float _zLowerBorder = -6.6f;

    void Update()
    {
        if (IsOutOfLeftBorder())
            StopPlayerAtLeftBorder();

        if (IsOutOfRightBorder())
            StopPlayerAtRightBorder();

        if (IsOutOfUpperBorder())
            StopPlayerAtUpperBorder();

        if (IsOutOfLowerBorder())
            StopPlayerAtLowerBorder();
    }

    private bool IsOutOfLeftBorder()
        => transform.position.x < -_xBorder;

    private bool IsOutOfRightBorder()
        => transform.position.x > _xBorder;

    private bool IsOutOfUpperBorder()
        => transform.position.z > _zUpperBorder;

    private bool IsOutOfLowerBorder()
        => transform.position.z < _zLowerBorder;

    private void StopPlayerAtLeftBorder()
        => transform.position = new Vector3(-_xBorder, transform.position.y, transform.position.z);
    
    private void StopPlayerAtRightBorder()
        => transform.position = new Vector3(_xBorder, transform.position.y, transform.position.z);

    private void StopPlayerAtUpperBorder()
        => transform.position = new Vector3(transform.position.x, transform.position.y, _zUpperBorder);

    private void StopPlayerAtLowerBorder()
        => transform.position = new Vector3(transform.position.x, transform.position.y, _zLowerBorder);
}