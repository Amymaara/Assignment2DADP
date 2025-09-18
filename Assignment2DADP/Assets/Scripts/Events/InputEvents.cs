using UnityEngine;
using System;

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
