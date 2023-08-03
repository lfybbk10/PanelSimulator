
using DG.Tweening;
using UnityEngine;

public class AutoButton : Activable
{
    [SerializeField] private Transform activePosition, deactivePosition;
    [SerializeField] private GameObject btnObject;
    
    private const float AnimationDuration = 0.5f;

    public override void Activate()
    {
        base.Activate();
        ClickAnimation();
    }

    private void ClickAnimation()
    {
        btnObject.transform.DOMove(activePosition.position, AnimationDuration).OnComplete((() =>
        {
            btnObject.transform.DOMove(deactivePosition.position, AnimationDuration).OnComplete((Deactivate));
        }));
    }
}
