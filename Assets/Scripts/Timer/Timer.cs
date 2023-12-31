﻿using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ScenarioController scenarioController;
    
    public Action<float> OnTimeChanged;
    
    public float Time { get; private set; }

    private bool _isDisabled;

    private void OnEnable()
    {
        scenarioController.OnScenarioCompleted += DisableTimer;
        scenarioController.OnScenarioFailed += DisableTimer;
    }

    private void OnDisable()
    {
        scenarioController.OnScenarioCompleted -= DisableTimer;
        scenarioController.OnScenarioFailed -= DisableTimer;
    }

    private void DisableTimer()
    {
        _isDisabled = true;
    }

    private void Update()
    {
        if (!_isDisabled)
        {
            Time += UnityEngine.Time.deltaTime;
            OnTimeChanged?.Invoke(Time);
        }
    }
}
