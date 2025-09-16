using UnityEngine;

public abstract class QuestSteps : MonoBehaviour
{
   private bool isFinished = false;
    
    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
           
            //TODO - advance quest forward now that finish step

            Destroy(this.gameObject);
        }
    }
   
}
