using UnityEngine;

public class PotionStep1 : QuestSteps
{
    [SerializeField] private TarotManager tarotManager;
    [SerializeField] private CatTeleport catTeleport;
    private bool waitingForDialogue;
    //chat helped

    public void CompleteFromTarot()
    {

    
        Debug.Log("[PotionStep1] Tarot spread opened — completing step.");
        if (waitingForDialogue) return;
        waitingForDialogue = true;

        GameEventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;

    }

    private void DialogueFinished()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        Debug.Log("cat spawning at potion");

        Object.FindFirstObjectByType<CatTeleport>()?.SpawnCatPotion();

        FinishQuestStep();
    }

}
