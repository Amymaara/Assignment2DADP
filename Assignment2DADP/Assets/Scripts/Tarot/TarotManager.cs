using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

public class TarotManager : MonoBehaviour
{
    [Header("UI")]
    public DisplayTarotReading displayTarotReading;
    public ObjectiveUI objectiveUI;


    [Header("switch inputs")]
    public PlayerInput playerInput;
    public string playerActionMapName = "Player";
    public string uiActionMapName = "UI";

    private DaySequence.Entry currentEntry;
    private bool tutorialSession = false;

    void Awake()
    {
       
        if (displayTarotReading && displayTarotReading.continueButton)
        {
            displayTarotReading.continueButton.onClick.RemoveAllListeners();
            displayTarotReading.continueButton.onClick.AddListener(Close);
        }
    }

    public void OpenWithEntry(DaySequence.Entry entry)
    {
        tutorialSession = false;
        OpenTarot();
    }

    public void OpenTarotPreset(TarotPreset preset)
    {
        if (!preset) return;

        tutorialSession = true;

        currentEntry = new DaySequence.Entry()
        {
            tarotCard1 = preset.card1,
            tarotCard2 = preset.card2,
            tarotCard3 = preset.card3,
            recipeSprite = preset.recipeCard,
            fixedOrder = preset.order,
        };

        OpenTarot();
    }
    private void OpenTarot()
    {
        if (displayTarotReading)
        {
            displayTarotReading.gameObject.SetActive(true);
            displayTarotReading.ShowEntry(currentEntry, resetCardsToBack: true);
        }

        if (playerInput) playerInput.SwitchCurrentActionMap(uiActionMapName);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Close()
    {
       if (displayTarotReading) displayTarotReading.gameObject.SetActive(false);

       if (playerInput) playerInput.SwitchCurrentActionMap(playerActionMapName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (objectiveUI && currentEntry.fixedOrder)
        {
          //  objectiveUI.SetObjective(currentEntry.fixedOrder.displayName);
            objectiveUI.SetRecipe(currentEntry.recipeSprite);
            objectiveUI.ShowObjectiveCard();
        }

        var spawner = FindFirstObjectByType<CustomerSpawner>();
        spawner?.MarkOrderRevealed();
    }
}
