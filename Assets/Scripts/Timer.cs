using System;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public Action<float> OnTimeChanged;
    
    private float _time;

    private bool _isEnabled;

    private void Update()
    {
        if (_isEnabled)
        {
            _time += Time.deltaTime;
            OnTimeChanged?.Invoke(_time);
        }
    }
}
