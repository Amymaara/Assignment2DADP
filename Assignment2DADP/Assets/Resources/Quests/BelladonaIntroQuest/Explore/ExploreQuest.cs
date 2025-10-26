using UnityEngine;

public class ExploreQuest : QuestSteps
{
    [Header("Settings")]
    public float autoCompleteDelay = 1f;
    [SerializeField] private CandleManager candleManager;


    private void Start()
    {
        Invoke(nameof(FinishStep), autoCompleteDelay);

    }

    void FinishStep()
    {
        Debug.Log("[QuestTest] Completing step now!");
        FinishQuestStep();
    }

    protected override void SetQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
