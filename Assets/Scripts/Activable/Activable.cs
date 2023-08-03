
using System;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    public bool IsActive { get; protected set; }

    public virtual void Activate()
    {
        IsActive = true;
    }

    public virtual void Deactivate()
    {
        IsActive = false;
    }
}
