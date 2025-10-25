using System.Runtime.CompilerServices;
using UnityEngine;



public class BelladonaAcceptsKnowledgePotion : QuestSteps
{
    [SerializeField] private ItemSO KnowledgePotion;
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

    
    public void TryHandInPotion()
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
