using UnityEngine;
using UnityEngine.InputSystem;


public class TarotPileInteractable : MonoBehaviour, IInteractable
{
    public CustomerSpawner spawner;
    public TarotManager tarotManager;

    public void Interact()
    {
       /* Debug.Log("[TarotPile] Interact called");

        if (!spawner) { Debug.LogError("[TarotPile] Missing spawner"); return; }
        if (!tarotManager) { Debug.LogError("[TarotPile] Missing TarotManager"); return; }
        if (!spawner.HasActiveCustomer) { Debug.Log("[TarotPile] No active customer"); return; }
        if (spawner.OrderRevealed) { Debug.Log("[TarotPile] Already revealed for this customer"); return; }
       */

        tarotManager.OpenWithEntry(spawner.CurrentEntry);
    }
}
