using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LightIndicator : Activable
{
    private Renderer _renderer;
    
    private Color _activeColor = Color.green;
    
    private Color _deactiveColor = Color.red;
    
    private Color _turnOffColor = Color.gray;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Activate()
    {
        base.Activate();
        _renderer.material.color = _activeColor;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _renderer.material.color = _deactiveColor;
    }

    public void TurnOn()
    {
        _renderer.material.color = IsActive ? _activeColor : _deactiveColor;
    }

    public void TurnOff()
    {
        _renderer.material.color = _turnOffColor;
    }
}
