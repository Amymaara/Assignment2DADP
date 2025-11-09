using UnityEngine;

public class CatStartDay1 : QuestSteps
{
    [SerializeField] private TimerBar timer;

    private void Awake()
    {
        timer = FindFirstObjectByType<TimerBar>(FindObjectsInactive.Include);
    }
    protected override void SetQuestStepState(string state)
    {
        if (state == "FINISHED")
            FinishQuestStep();
    }

    private void OnEnable()
    {
        if (timer == null)
        {
            timer = FindFirstObjectByType<TimerBar>(FindObjectsInactive.Include);
        }
        if (timer != null)
            timer.OnDayFinished += HandleDayFinished;
    }

    private void OnDisable()
    {
        if (timer != null)
            timer.OnDayFinished -= HandleDayFinished;
    }

    private void HandleDayFinished(bool success)
    {
        if (!success) return;
        ChangeState("FINISHED");
        FinishQuestStep();
    }
}
