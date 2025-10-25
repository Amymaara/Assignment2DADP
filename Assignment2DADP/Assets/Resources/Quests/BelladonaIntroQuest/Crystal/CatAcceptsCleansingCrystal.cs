using UnityEngine;

public class CatAcceptsCleansingCrystal : QuestSteps
{
    [SerializeField] private ItemSO CleansingCrystal;
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

    public void TryHandInCrystal()
    {
        if (waitingForDialogue) return;
        waitingForDialogue = true;

        FinishQuestStep();
    }


    protected override void SetQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
