using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScenario : MonoBehaviour
{
    [SerializeField] private ScenarioController _scenarioController;

    [SerializeField] private Text _scenarioText, _errorText;

    private readonly List<string> _scenarioLabels = new List<string>();

    private const string ScenarioLabelsPath = "labels";
    
    private int _currScenarioLabelsIndex;

    private void Awake()
    {
        foreach (var label in Resources.Load<TextAsset>(ScenarioLabelsPath).text.Split("\n"))
        {
            _scenarioLabels.Add(label);
        }
    }

    private void Start()
    {
        UpdateScenarioText();
    }

    private void OnEnable()
    {
        _scenarioController.OnScenarioStepCompleted += SwitchLabel;
        _scenarioController.OnErrorMade += UpdateErrorText;
    }

    private void OnDisable()
    {
        _scenarioController.OnScenarioStepCompleted -= SwitchLabel;
        _scenarioController.OnErrorMade -= UpdateErrorText;
    }

    private void SwitchLabel()
    {
        _currScenarioLabelsIndex++;
        if(_currScenarioLabelsIndex==_scenarioLabels.Count)
            return;
        UpdateScenarioText();
    }

    private void UpdateScenarioText()
    {
        _scenarioText.text = _scenarioLabels[_currScenarioLabelsIndex];
    }

    private void UpdateErrorText()
    {
        StopCoroutine(FadeOutErrorText());
        var textColor = _errorText.color;
        textColor.a = 1;
        _errorText.color = textColor;
        _errorText.text = "Ошибка!";
        StartCoroutine(FadeOutErrorText());
    }

    private IEnumerator FadeOutErrorText()
    {
        yield return new WaitForSeconds(0.4f);
        var textColor = _errorText.color;
        for (int i = 1; i <= 51; i++)
        {
            textColor.a -= 5 / 255f;
            _errorText.color = textColor;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
