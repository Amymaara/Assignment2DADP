using UnityEngine;

public abstract class QuestSteps : MonoBehaviour
{
   private bool isFinished = false;

    private string questId;
    
    public void IntiatialiseQuestStep(string questId)
    {
        this.questId = questId;
    }
    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
   
}
