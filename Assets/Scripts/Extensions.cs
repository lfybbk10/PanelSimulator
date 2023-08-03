
using UnityEngine;

public static class Extensions
{
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
