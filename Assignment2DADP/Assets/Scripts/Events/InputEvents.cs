using UnityEngine;
using System;

public class InputEvents
{
    public event Action onInteractPressed;

    public void InteractPressed()
    {
        if (onInteractPressed != null)
        {
            onInteractPressed();
            UnityEngine.Debug.Log("[InputEvents] fired bus: onInteractPressed invoked");
        }
    }
}
