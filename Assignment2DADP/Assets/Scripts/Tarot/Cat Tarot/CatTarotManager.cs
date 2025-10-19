using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

public class CatTarotManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject tarotCanvas;                          
    public Button continueButton;
    public GameObject objectiveCanvas;


    [Header("switch inputs")]
    public PlayerInput playerInput;
    public string playerActionMapName = "Player";
    public string uiActionMapName = "UI";

    private bool isOpen;

    void Awake()
    {

        if (tarotCanvas) tarotCanvas.SetActive(false);
        if (objectiveCanvas) objectiveCanvas.SetActive(false);

        if (!continueButton && tarotCanvas) 
            continueButton = tarotCanvas.GetComponentInChildren<Button>(true);

        if (continueButton)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(CloseTarotAndShowObjective);
        }
    }

    public void Interact()
    {
        if (!isOpen) OpenTarot();
    }

    public void OpenTarot()
    {
        if (!tarotCanvas)
        {
            Debug.Log("tarot canvas not assigned");
            return;
        }

        var t = tarotCanvas.transform;
        while (t)
        {
            if (!t.gameObject.activeSelf)
            {
                t.gameObject.SetActive(true);
                t = t.parent;
            }
        }

        tarotCanvas.SetActive(true);

        if (playerInput) playerInput.SwitchCurrentActionMap(uiActionMapName);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isOpen = true; 
    }

    public void CloseTarotAndShowObjective()
    {
        if (tarotCanvas) tarotCanvas.SetActive(false);

        if (objectiveCanvas)
        {
            var t = objectiveCanvas.transform;
            while (t)
            {
                if (!t.gameObject.activeSelf)
                {
                    t.gameObject.SetActive(true);
                }
            }
            objectiveCanvas.SetActive(true);
        }

        if (playerInput) playerInput.SwitchCurrentActionMap(playerActionMapName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isOpen = false;
    }

}
