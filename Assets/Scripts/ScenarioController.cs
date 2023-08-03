using System;
using System.Collections.Generic;
using UnityEngine;


public class ScenarioController : Singleton<ScenarioController>
{
    [SerializeField] private List<ScenarioElement> scenarioElems = new List<ScenarioElement>();
    
    [SerializeField] private int _maxErrorsCount;

    [SerializeField] private ActivableInput activableInput;
    
    public Action OnScenarioStepCompleted, OnErrorMade, OnScenarioCompleted, OnScenarioFailed;

    private int _currErrorsCount;

    private int _currScenarioElemsIndex;
    
    private void OnEnable()
    {
        activableInput.OnActivated += OnActivated;
        activableInput.OnDeactivated += OnDeactivated;
    }

    private void OnDisable()
    {
        activableInput.OnActivated -= OnActivated;
        activableInput.OnDeactivated -= OnDeactivated;
    }

    private void OnActivated(Activable activable)
    {
        if (scenarioElems.FindIndex(elem=>elem._activable == activable) == _currScenarioElemsIndex && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Activate)
            NextStep();
        else
            MakeError();
    }
    
    private void OnDeactivated(Activable activable)
    {
        if (scenarioElems.FindIndex(elem=>elem._activable == activable) == _currScenarioElemsIndex && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Deactivate)
            NextStep();
        else
            MakeError();
    }
    
    private void NextStep()
    {
        _currScenarioElemsIndex++;
        OnScenarioStepCompleted?.Invoke();
        if(_currScenarioElemsIndex==scenarioElems.Count)
            OnScenarioCompleted?.Invoke();
    }

    private void MakeError()
    {
        OnErrorMade?.Invoke();
        _currErrorsCount++;
        if(_currErrorsCount==_maxErrorsCount)
            OnScenarioFailed?.Invoke();
    }
}
