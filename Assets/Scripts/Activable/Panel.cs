
using System;

public class Panel : Activable
{
    public Action OnPanelTurnOn, OnPanelTurnOff;
    
    public override void Activate()
    {
        base.Activate();
        OnPanelTurnOn?.Invoke();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        OnPanelTurnOff?.Invoke();
    }
}
