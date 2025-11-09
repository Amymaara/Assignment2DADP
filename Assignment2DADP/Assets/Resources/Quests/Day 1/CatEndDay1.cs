using UnityEngine;

public class CatEndDay1 : QuestSteps
{
    private bool sawSuccess;

    private void OnEnable()
    {
         
    }

    private void OnDisable()
    {
        
    }

    private void OnDayEnded(bool success)
    {
        if (!success || sawSuccess) return;
        sawSuccess = true;

        ChangeState("SUCCESS");
        FinishQuestStep();
    }

    protected override void SetQuestStepState(string state)
    {
        sawSuccess = state == "SUCCESS";
        if (sawSuccess) FinishQuestStep();
    }

}
