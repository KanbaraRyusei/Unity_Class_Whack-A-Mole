using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float Timer => _timer;

    private float _timer;
    private float _oldTimer;
    private bool _isStopTimer = true;

    private void Update()
    {
        if (_isStopTimer) return;
        _timer += Time.deltaTime;
    }

    public void StartTimer()
    {
        _isStopTimer = false;
        _timer = 0f;
    }

    public void RestartTimer()
    {
        _isStopTimer = false;
        _timer = _oldTimer;
    }

    public void StopTimer()
    {
        _isStopTimer = true;
        _oldTimer = _timer;
    }

    public void ResetTimer()
    {
        _isStopTimer = true;
        _timer = 0f;
    }
}
