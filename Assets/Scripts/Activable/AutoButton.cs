
using DG.Tweening;
using UnityEngine;

public class AutoButton : Activable
{
    [SerializeField] private Transform _activePosition, _deactivePosition;
    [SerializeField] private GameObject _btnObject;

    public override void Activate()
    {
        base.Activate();
        _btnObject.transform.DOMove(_activePosition.position, 0.5f).OnComplete((() =>
        {
            _btnObject.transform.DOMove(_deactivePosition.position, 0.5f).OnComplete((() =>
            {
                IsActive = false;
            }));
        }));
    }
}
