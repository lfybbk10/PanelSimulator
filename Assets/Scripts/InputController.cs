using System;
using UnityEngine;


public class InputController : MonoBehaviour
{
    [SerializeField] private LayerMask _activableMask;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out var hit))
            {
                if (_activableMask.Contains(hit.transform.gameObject.layer))
                {
                    hit.collider.GetComponent<Activable>().Activate();
                }
            }
        }
    }
}
