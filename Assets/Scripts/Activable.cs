﻿
using System;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    private static readonly List<Activable> _instances = new ();

    public static IReadOnlyList<Activable> Instances => _instances;

    public Action<Activable> OnActivated, OnDeactivated;
    
    public bool IsActive { get; protected set; }

    protected virtual void Awake()
    {
        _instances.Add(this);
    }

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

    private void OnDestroy()
    {
        _instances.Remove(this);
    }
}
