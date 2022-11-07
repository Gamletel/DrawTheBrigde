using System;
using UnityEngine;

public class MovingObjectHandler : MonoBehaviour
{
    public Vector3[] points; // ����� ������
    public float[] time; // ����� �� ��������� �����
    private int _current = 0;
    private float _timer = 0f;
    private int _next = 1;
    private bool _isStatic = false;

    void Update()
    {
        if (!_isStatic)
            try
            {
                transform.position = Vector3.Lerp(points[_current], points[_next], _timer / time[_current]);
                _timer += Time.deltaTime;
                if (_timer >= time[_current])
                {
                    _timer = 0f;
                    _current = _next;
                    _next++;
                    if (_next == points.Length) _next = 0;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogWarning("��������� ��������!");
                _isStatic = true;
                throw;
            }

    }
}
