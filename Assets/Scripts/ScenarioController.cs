using System;
using System.Collections.Generic;
using UnityEngine;


public class ScenarioController : Singleton<ScenarioController>
{
    [SerializeField] private List<ScenarioElement> scenarioElems = new List<ScenarioElement>();
    
    [SerializeField] private int maxErrorsCount;

    [SerializeField] private ActivableInput activableInput;
    
    public int CurrErrorsCount { get; private set; }
    
    public Action OnScenarioStepCompleted, OnErrorMade, OnScenarioCompleted, OnScenarioFailed;
    
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
        if (scenarioElems[_currScenarioElemsIndex]._activable == activable && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Activate)
            NextStep();
        else
        {
            MakeError();
            activable.Deactivate();
        }
    }
    
    private void OnDeactivated(Activable activable)
    {
        if (scenarioElems[_currScenarioElemsIndex]._activable == activable && scenarioElems[_currScenarioElemsIndex]._state==ActivateState.Deactivate)
            NextStep();
        else
        {
            MakeError();
            activable.Activate();
        }
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
        CurrErrorsCount++;
        if (CurrErrorsCount == maxErrorsCount)
            OnScenarioFailed?.Invoke();
    }
}
