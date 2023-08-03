using System;
using System.Collections.Generic;
using UnityEngine;


public class ScenarioController : Singleton<ScenarioController>
{
    [SerializeField] private List<ScenarioElement> scenarioElems = new List<ScenarioElement>();

    public Action OnScenarioStepCompleted, OnErrorMade, OnSuccess, OnFail;

    private int _maxErrorsCount = 3;

    private int _currErrorsCount;

    private int _currScenarioElemsIndex;

    private void OnEnable()
    {
        foreach (var activable in Activable.Instances)
        {
            activable.OnActivated += OnActivated;
            activable.OnDeactivated += OnDeactivated;
        }
    }

    private void OnDisable()
    {
        foreach (var activable in Activable.Instances)
        {
            activable.OnActivated -= OnActivated;
            activable.OnDeactivated -= OnDeactivated;
        }
    }

    private void OnActivated(Activable activable)
    {
        if (scenarioElems.FindIndex(elem=>elem._activable == activable) == _currScenarioElemsIndex && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Activate)
        {
            NextStep();
        }
        else
        {
            MakeError();
        }
    }
    
    private void OnDeactivated(Activable activable)
    {
        if (scenarioElems.FindIndex(elem=>elem._activable == activable) == _currScenarioElemsIndex && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Deactivate)
        {
            NextStep();
        }
        else
        {
            MakeError();
        }
    }

    private void NextStep()
    {
        _currScenarioElemsIndex++;
        OnScenarioStepCompleted?.Invoke();
        if(_currScenarioElemsIndex==scenarioElems.Count)
            OnSuccess?.Invoke();
    }

    private void MakeError()
    {
        OnErrorMade?.Invoke();
        _currErrorsCount++;
        if(_currErrorsCount==_maxErrorsCount)
            OnFail?.Invoke();
    }
}
