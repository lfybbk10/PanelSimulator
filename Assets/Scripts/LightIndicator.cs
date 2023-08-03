using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LightIndicator : Activable
{
    private Renderer _renderer;
    
    private Color _activeColor = Color.green;
    
    private Color _deactiveColor = Color.red;
    
    private Color _turnOffColor = Color.gray;

    private bool _isTurnOn;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Activate()
    {
        base.Activate();
        _renderer.material.color = _isTurnOn ? _activeColor : _turnOffColor;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _renderer.material.color = _isTurnOn ? _deactiveColor : _turnOffColor;
    }

    public void TurnOn()
    {
        _isTurnOn = true;
        _renderer.material.color = IsActive ? _activeColor : _deactiveColor;
    }

    public void TurnOff()
    {
        _isTurnOn = false;
        _renderer.material.color = _turnOffColor;
    }
}
