using System;
using UnityEngine;

public class ActivableInput : MonoBehaviour
{
    [SerializeField] private ScenarioController scenarioController;
    [SerializeField] private LayerMask activableMask;

    public Action<Activable> OnActivated, OnDeactivated;

    private bool _isInputDisabled;

    private void OnEnable()
    {
        scenarioController.OnScenarioCompleted += DisableInput;
        scenarioController.OnScenarioFailed += DisableInput;
    }

    private void OnDisable()
    {
        scenarioController.OnScenarioCompleted -= DisableInput;
        scenarioController.OnScenarioFailed -= DisableInput;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isInputDisabled)
        {
            Vector3 screenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out var hit))
            {
                if (activableMask.Contains(hit.transform.gameObject.layer))
                {
                    var activable = hit.collider.GetComponent<Activable>();
                    InteractActivable(activable);
                }
            }
        }
    }

    private void InteractActivable(Activable activable)
    {
        if (!activable.IsActive)
        {
            activable.Activate();
            OnActivated?.Invoke(activable);
        }
        else
        {
            activable.Deactivate();
            OnDeactivated?.Invoke(activable);
        }
    }

    private void DisableInput() => _isInputDisabled = true;

    private void EnableInput() => _isInputDisabled = false;
}
