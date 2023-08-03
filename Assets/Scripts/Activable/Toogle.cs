using DG.Tweening;
using UnityEngine;

public class Toogle : Activable
{
    [SerializeField] private Panel panel;
    [SerializeField] private LightIndicator lightIndicator;
    [SerializeField] private GameObject arm;
    [SerializeField] private bool isActivated;

    private const float RotateAnimationDuration = 0.5f;

    private const int ActivateXAngle = -30;
    private const int DeActivateXAngle = -120;

    private void Start()
    {
        if (isActivated)
            Activate();
        else
            Deactivate();
    }

    private void OnEnable()
    {
        panel.OnPanelTurnOn += EnableLightIndicator;
        panel.OnPanelTurnOff += DisableLightIndicator;
    }

    private void OnDisable()
    {
        panel.OnPanelTurnOn -= EnableLightIndicator;
        panel.OnPanelTurnOff -= DisableLightIndicator;
    }

    public override void Activate()
    {
        base.Activate();
        lightIndicator.Activate();
        arm.transform.DORotate(new Vector3(ActivateXAngle, 0, 0),RotateAnimationDuration);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        lightIndicator.Deactivate();
        arm.transform.DORotate(new Vector3(DeActivateXAngle, 0, 0),RotateAnimationDuration);
    }

    private void EnableLightIndicator() => lightIndicator.TurnOn();
    
    private void DisableLightIndicator() => lightIndicator.TurnOff();
}
