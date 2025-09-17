using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputManager : MonoBehaviour
{
    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("[PIM] Interact performed → firing bus");
            GameEventsManager.instance.inputEvents.InteractPressed();
        }
    }
}
