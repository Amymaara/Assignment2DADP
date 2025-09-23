using UnityEngine;

public class PotionStep1 : QuestSteps
{
    [SerializeField] private TarotManager tarotManager;
    [SerializeField] private CatTeleport catTeleport;
    [SerializeField] private CandleManager candleManager;
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

        if (candleManager == null)
        {
            var mgrRoot = GameObject.Find("Managers");
            if (mgrRoot != null)
                candleManager = mgrRoot.GetComponentInChildren<CandleManager>(true);
        }

        candleManager.TurnOnPotionCandles();

    }

}
