using UnityEngine;
// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
public abstract class QuestSteps : MonoBehaviour
{
   private bool isFinished = false;

    private string questId;
    private int stepIndex;
    
    public void IntiatialiseQuestStep(string questId, int stepIndex, string questStepState)
    {
        this.questId = questId;
        this.stepIndex = stepIndex;
        if (questStepState != null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
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
   
    protected void ChangeState(string newState)
    {
        GameEventsManager.instance.questEvents.QuestStepStateChange(questId, stepIndex,new QuestStepState(newState));
    }

    protected abstract void SetQuestStepState(string state);
}
