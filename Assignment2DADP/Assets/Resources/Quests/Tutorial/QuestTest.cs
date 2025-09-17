using UnityEngine;

public class QuestTest : QuestSteps
{
    [Header("Settings")]
    public float autoCompleteDelay = 5f;

    private void Start()
    {
        Debug.Log("[SimpleQuestStep] Started step, will finish after delay...");
        Invoke(nameof(FinishStep), autoCompleteDelay);
    }

    void FinishStep()
    {
        Debug.Log("[SimpleQuestStep] Completing step now!");
        FinishQuestStep();  
    }
}
