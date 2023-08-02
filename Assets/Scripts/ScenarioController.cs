using System;
using System.Collections.Generic;
using UnityEngine;


public class ScenarioController : Singleton<ScenarioController>
{
    [SerializeField] private List<Activable> scenarioElems = new List<Activable>();

    public Action OnScenarioStepCompleted, OnErrorMade;

    private int _currScenarioElemsIndex;

    private void OnEnable()
    {
        foreach (var activable in Activable.Instances)
        {
            activable.OnActivated += OnActivated;
        }
    }

    private void OnDisable()
    {
        foreach (var activable in Activable.Instances)
        {
            activable.OnActivated -= OnActivated;
        }
    }

    private void OnActivated(Activable activable)
    {
        if (scenarioElems.Contains(activable) && scenarioElems.IndexOf(activable) == _currScenarioElemsIndex)
        {
            _currScenarioElemsIndex++;
            OnScenarioStepCompleted?.Invoke();
        }
        else
        {
            OnErrorMade?.Invoke();
        }
    }
}
