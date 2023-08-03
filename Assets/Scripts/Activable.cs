
using System;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    
    public Action<Activable> OnActivated, OnDeactivated;
    
    public bool IsActive { get; protected set; }

    public virtual void Activate()
    {
        IsActive = true;
        OnActivated?.Invoke(this);
    }

    public virtual void Deactivate()
    {
        IsActive = false;
        OnDeactivated?.Invoke(this);
    }
}
