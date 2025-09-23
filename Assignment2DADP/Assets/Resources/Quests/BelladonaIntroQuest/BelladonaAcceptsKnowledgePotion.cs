using UnityEngine;

/*
public class BelladonaAcceptsKnowledgePotion : QuestSteps
{
    public void PotionHandedIn()
    {
        FinishQuestStep();
    }
}


*/


public class BelladonaAcceptsKnowledgePotion : QuestSteps
{
    [SerializeField] private ItemSO knowledgePotion;
    [SerializeField] private string playerTag = "Player";

    private bool playerNear = false;
    private Transform playerTf;
    private bool waitingForDialogue;

    public CatTeleport catTeleport;

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

    // This should be wired to your Interact input event
    public void TryHandInPotion()
    {
        if (waitingForDialogue) return;
        waitingForDialogue = true;

        GameEventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;

        /*
        if (!playerNear || playerTf == null) return;

        var held = playerTf.GetComponentInChildren<ServeableItem>(true);
        if (held == null)
        {
            Debug.Log("You're not holding anything.");
            return;
        }

        if (held.item == knowledgePotion)
        {
            Debug.Log("Belladona accepts the potion!");
            Destroy(held.gameObject); // consume it
            
            if (waitingForDialogue) return;
            waitingForDialogue = true;

            GameEventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        }
        else
        {
            Debug.Log("This is not the correct potion.");
        }
        */
    }

    private void DialogueFinished()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        Object.FindFirstObjectByType<CatTeleport>()?.SpawnCatTable();
        FinishQuestStep();       

    }
}
