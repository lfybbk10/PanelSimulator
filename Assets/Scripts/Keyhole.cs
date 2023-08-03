using DG.Tweening;
using UnityEngine;

public class Keyhole : Activable
{
    [SerializeField] private Panel _panel;
    [SerializeField] private GameObject _keyPrefab;

    private GameObject _key;

    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public override void Activate()
    {
        base.Activate();
        _key = Instantiate(_keyPrefab, _camera.transform.position, Quaternion.identity);
        _key.transform.DOMove(transform.position, 1f).OnComplete((() =>
        {
            _key.transform.DORotate(new Vector3(_key.transform.rotation.x, 0, _key.transform.rotation.z), 0.5f).OnComplete((TurnOnPanel));
        }));
        
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _key.transform.DORotate(new Vector3(_key.transform.rotation.x, -90, _key.transform.rotation.z), 0.5f)
            .OnComplete((
                () =>
                {
                    TurnOffPanel();
                    _key.transform.DOMove(_camera.transform.position, 1f);
                }));
    }

    private void TurnOnPanel()
    {
        _panel.Activate();
    }

    private void TurnOffPanel()
    {
        _panel.Deactivate();
    }
}
