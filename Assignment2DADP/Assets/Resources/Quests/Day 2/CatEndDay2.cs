using UnityEngine;

public class CatEndDay2 : QuestSteps
{
    [Header("Settings")]
    public float autoCompleteDelay = 1f;

    private void Start()
    {
        Invoke(nameof(FinishStep), autoCompleteDelay);

    }

    void FinishStep()
    {
        //Debug.Log("[] Completing step now!");
        FinishQuestStep();
    }

    protected override void SetQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }

}
