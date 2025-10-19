using UnityEngine;

public class CatAcceptsProtectionRUne : QuestSteps
{
    [SerializeField] private ItemSO ProtectionRune;
    [SerializeField] private string playerTag = "Player";

    private bool playerNear = false;
    private Transform playerTf;
    private bool waitingForDialogue;

    public CatTeleport catTeleport;
    public CandleManager candleManager;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        playerNear = true;
        playerTf = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        playerNear = false;
        playerTf = null;
    }

    public void TryHandInRune()
    {
        if (waitingForDialogue) return;
        waitingForDialogue = true;

        GameEventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;

    }

    private void DialogueFinished()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        Object.FindFirstObjectByType<CatTeleport>()?.SpawnCatCrystal();
        FinishQuestStep();

       if (candleManager == null)
        {
            var mgrRoot = GameObject.Find("Managers");
            if (mgrRoot != null)
                candleManager = mgrRoot.GetComponentInChildren<CandleManager>(true);
        }

        candleManager.TurnOnExploreCandles();

    }

    protected override void SetQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
