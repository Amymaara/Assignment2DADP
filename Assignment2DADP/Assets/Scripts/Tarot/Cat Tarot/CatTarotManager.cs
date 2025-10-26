using System.Collections;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

// Script: CatTarotManager.cs
// Purpose: Manages the Tarot deck interaction and transitions between the tarot and objective canvases.
// Author: Ammaarah Cassim
// Collaboration: Debugged and refined with the assistance of ChatGPT (OpenAI)
// Date: 26 October 2025
public class CatTarotManager : MonoBehaviour, IInteractable
{
    [Header("GameObjects)")]
    public GameObject tarotCanvasRoot;      
    public GameObject objectiveCanvasRoot;  

    [Header("Continue button")]
    public Button continueButton;

    

    private static CatTarotManager s_openDeck;
    private bool _open;
    public static CatTarotManager Current => s_openDeck;

 

    void Awake()
    {
  
        if (!tarotCanvasRoot) Debug.LogError($"[{name}] Tarot canvas root not assigned.");
        if (!objectiveCanvasRoot) Debug.LogWarning($"[{name}] Objective canvas root not assigned (ok if none).");

        // Ensure both roots exist & start hidden
        if (tarotCanvasRoot) tarotCanvasRoot.SetActive(false);
        if (objectiveCanvasRoot) objectiveCanvasRoot.SetActive(false);

     
        if (continueButton)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(ShowObjective);
        }
        
     
    }

   


  
    public void Interact()
    {
        if (_open) return;

        // Close any other deck 
        if (s_openDeck && s_openDeck != this)
            s_openDeck.ForceClose();

        ShowTarot();
        s_openDeck = this;
        _open = true;
        DeckSignal.DeckOpened();
    }

    public void ShowTarot()
    {
        if (objectiveCanvasRoot) objectiveCanvasRoot.SetActive(false);
        if (tarotCanvasRoot) tarotCanvasRoot.SetActive(true);

        if (continueButton) continueButton.interactable = false;

        foreach (var f in tarotCanvasRoot.GetComponentsInChildren<FlipCards>(true))
            f.ResetState();



        s_openDeck = this;
        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;

        GameEventsManager.instance.inputEvents.ChangeInputEventsContext(InputEventsContext.TAROT);
    }

    public void ShowObjective()
    {
        if (tarotCanvasRoot) tarotCanvasRoot.SetActive(false);
        if (objectiveCanvasRoot) objectiveCanvasRoot.SetActive(true);

        _open = false;
        if (s_openDeck == this) s_openDeck = null;

      
         Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;

        GameEventsManager.instance.inputEvents.ChangeInputEventsContext(InputEventsContext.DEFAULT);
    }

    private void ForceClose()
    {
        if (tarotCanvasRoot) tarotCanvasRoot.SetActive(false);
        if (objectiveCanvasRoot) objectiveCanvasRoot.SetActive(false);
        _open = false;
        if (s_openDeck == this) s_openDeck = null;
    }
}
