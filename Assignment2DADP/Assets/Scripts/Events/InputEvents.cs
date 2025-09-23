using UnityEngine;
using System;

// dialogue system 
// Title: How to create a Dialogue System in Unity | RPG Style | Unity + Ink
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=l8yI_97vjZs&t=1227s
public class InputEvents
{
    public InputEventsContext inputEventsContext { get; private set; } = InputEventsContext.DEFAULT;

    public void ChangeInputEventsContext(InputEventsContext newContext)
    {
        this.inputEventsContext = newContext;
    }
    public event Action<InputEventsContext> onInteractPressed;

    public void InteractPressed()
    {
        if (onInteractPressed != null)
        {
            onInteractPressed(this.inputEventsContext);
        }
    }
}
