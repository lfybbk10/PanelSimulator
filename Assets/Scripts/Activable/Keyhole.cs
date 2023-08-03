using DG.Tweening;
using UnityEngine;

public class Keyhole : Activable
{
    [SerializeField] private Panel panel;
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private Transform keyPosition;

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
        _key = Instantiate(keyPrefab, _camera.transform.position, keyPrefab.transform.rotation);
        ActivateKeyAnimation();
    }

    private void ActivateKeyAnimation()
    {
        _key.transform.DOMove(keyPosition.position, MoveAnimationDuration).OnComplete((() =>
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
        _key.transform.DORotate(new Vector3(_key.transform.rotation.eulerAngles.x, -90, _key.transform.rotation.eulerAngles.z), RotateAnimationDuration)
            .OnComplete((
                () =>
                {
                    TurnOffPanel();
                    _key.transform.DOMove(_camera.transform.position, MoveAnimationDuration);
                }));
    }

    private void TurnOnPanel() => panel.Activate();

    private void TurnOffPanel() => panel.Deactivate();
}
