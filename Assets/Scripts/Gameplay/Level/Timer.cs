using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _startTime;
    private float _elapsedTime;
    private bool _isRunning;


    public void StartTimer()
    {
        if (!_isRunning)
        {
            _startTime = Time.time;
            _isRunning = true;
        }
    }

    public void StopTimer()
    {
        if (_isRunning)
        {
            _elapsedTime = Time.time - _startTime;
            _isRunning = false;
        }
    }

    public float GetElapsedTime()
    {
        return _elapsedTime;
    }

    
}