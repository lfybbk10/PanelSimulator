
using DG.Tweening;
using UnityEngine;

public class AutoButton : Activable
{
    [SerializeField] private Transform _activePosition, _deactivePosition;
    [SerializeField] private GameObject _btnObject;
    
    private const float AnimationDuration = 0.5f;

    public override void Activate()
    {
        base.Activate();
        ClickAnimation();
    }

    private void ClickAnimation()
    {
        _btnObject.transform.DOMove(_activePosition.position, AnimationDuration).OnComplete((() =>
        {
            _btnObject.transform.DOMove(_deactivePosition.position, AnimationDuration).OnComplete((Deactivate));
        }));
    }
}
