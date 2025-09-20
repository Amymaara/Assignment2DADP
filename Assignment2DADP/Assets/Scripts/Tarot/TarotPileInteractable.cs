using UnityEngine;
using UnityEngine.InputSystem;


public class TarotPileInteractable : MonoBehaviour, IInteractable
{
    public TarotManager tarotManager;
    public PlayerInput PlayerInput;
    public TarotReadings testReading;

    public void Interact()
    {
        tarotManager.OpenTarotSpread(testReading);
        PlayerInput.SwitchCurrentActionMap("Tarot");
    }
}
