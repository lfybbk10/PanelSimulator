using System;
using DG.Tweening;
using UnityEngine;


public class Toogle : Activable
{
    [SerializeField] private Panel _panel;
    [SerializeField] private LightIndicator _lightIndicator;
    [SerializeField] private GameObject _arm;

    private void OnEnable()
    {
        _panel.OnPanelTurnOn += EnableLightIndicator;
        _panel.OnPanelTurnOff += DisableLightIndicator;
    }

    private void OnDisable()
    {
        _panel.OnPanelTurnOn -= EnableLightIndicator;
        _panel.OnPanelTurnOff -= DisableLightIndicator;
    }

    public override void Activate()
    {
        base.Activate();
        _lightIndicator.Activate();
        _arm.transform.DORotate(new Vector3(30, 0, 0),0.5f);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _lightIndicator.Deactivate();
        _arm.transform.DORotate(new Vector3(-30, 0, 0),0.5f);
    }

    private void EnableLightIndicator() => _lightIndicator.TurnOn();
    
    private void DisableLightIndicator() => _lightIndicator.TurnOff();
}
