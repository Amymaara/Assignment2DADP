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
