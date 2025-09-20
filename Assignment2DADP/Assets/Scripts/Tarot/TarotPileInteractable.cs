using UnityEngine;
using UnityEngine.InputSystem;


public class TarotPileInteractable : MonoBehaviour, IInteractable
{
    public TarotManager tarotManager;
    public TarotReadings testReading;

    public void Interact()
    {
        tarotManager.OpenTarotSpread(testReading);
    }
}
