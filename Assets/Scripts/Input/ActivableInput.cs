using System;
using UnityEngine;


public class ActivableInput : MonoBehaviour
{
    [SerializeField] private ScenarioController _scenarioController;
    [SerializeField] private LayerMask _activableMask;

    public Action<Activable> OnActivated, OnDeactivated;

    private bool isInputEnabled = true;

    private void OnEnable()
    {
        _scenarioController.OnScenarioCompleted += DisableInput;
        _scenarioController.OnScenarioFailed += DisableInput;
    }

    private void OnDisable()
    {
        _scenarioController.OnScenarioCompleted -= DisableInput;
        _scenarioController.OnScenarioFailed -= DisableInput;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInputEnabled)
        {
            Vector3 screenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out var hit))
            {
                if (_activableMask.Contains(hit.transform.gameObject.layer))
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

    private void DisableInput()
    {
        isInputEnabled = false;
    }
    
    private void EnableInput()
    {
        isInputEnabled = true;
    }
}
