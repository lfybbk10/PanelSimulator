using DG.Tweening;
using UnityEngine;

public class Keyhole : Activable
{
    [SerializeField] private Panel _panel;
    [SerializeField] private GameObject _keyPrefab;
    [SerializeField] private Transform _keyPosition;

    private GameObject _key;

    private Camera _camera;

    private const float MoveAnimationDuration = 1f;
    private const float RotateAnimationDuration = 0.5f;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public override void Activate()
    {
        base.Activate();
        _key = Instantiate(_keyPrefab, _camera.transform.position, Quaternion.Euler(new Vector3(13,-95,23)));
        ActivateKeyAnimation();
    }

    private void ActivateKeyAnimation()
    {
        _key.transform.DOMove(_keyPosition.position, MoveAnimationDuration).OnComplete((() =>
        {
            _key.transform.DORotate(new Vector3(_key.transform.rotation.eulerAngles.x, 0, _key.transform.eulerAngles.z), RotateAnimationDuration).OnComplete((TurnOnPanel));
        }));
    }

    public override void Deactivate()
    {
        base.Deactivate();
        DeactivateKeyAnimation();
    }

    private void DeactivateKeyAnimation()
    {
        _key.transform.DORotate(new Vector3(_key.transform.rotation.eulerAngles.x, -95, _key.transform.rotation.eulerAngles.z), RotateAnimationDuration)
            .OnComplete((
                () =>
                {
                    TurnOffPanel();
                    _key.transform.DOMove(_camera.transform.position, MoveAnimationDuration);
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
