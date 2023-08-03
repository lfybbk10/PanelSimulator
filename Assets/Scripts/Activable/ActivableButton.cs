using DG.Tweening;
using UnityEngine;


public class ActivableButton : Activable
{
    [SerializeField] private Transform activePosition, deactivePosition;
    [SerializeField] private GameObject btnObject;

    private const float AnimationDuration = 0.5f;

    public override void Activate()
    {
        base.Activate();
        btnObject.transform.DOMove(activePosition.position, AnimationDuration);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        btnObject.transform.DOMove(deactivePosition.position, AnimationDuration);
    }
}
