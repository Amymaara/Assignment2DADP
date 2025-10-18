using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

public class CatTarotManager : MonoBehaviour
{
    [Header("UI")]
    public DisplayTarotReading displayTarotReading;
    public ObjectiveUI objectiveUI; // cat objective UI


    [Header("switch inputs")]
    public PlayerInput playerInput;
    public string playerActionMapName = "Player";
    public string uiActionMapName = "UI";

    private DaySequence.Entry currentEntry;

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
        currentEntry = entry;

        if (displayTarotReading)
        {
            displayTarotReading.gameObject.SetActive(true);
            displayTarotReading.ShowEntry(entry, resetCardsToBack: true);
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
