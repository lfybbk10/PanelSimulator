using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LightIndicator : Activable
{
    private Renderer _renderer;
    
    private Color _activeColor = Color.green;
    
    private Color _deactiveColor = Color.red;
    
    private Color _turnOffColor = Color.gray;

    private bool isTurnOn;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Activate()
    {
        base.Activate();
        _renderer.material.color = isTurnOn ? _activeColor : _turnOffColor;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _renderer.material.color = isTurnOn ? _deactiveColor : _turnOffColor;
    }

    public void TurnOn()
    {
        isTurnOn = true;
        _renderer.material.color = IsActive ? _activeColor : _deactiveColor;
    }

    public void TurnOff()
    {
        isTurnOn = false;
        _renderer.material.color = _turnOffColor;
    }
}
