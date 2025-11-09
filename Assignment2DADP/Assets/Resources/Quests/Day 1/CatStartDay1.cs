using UnityEngine;

public class CatStartDay1 : QuestSteps
{
    protected override void SetQuestStepState(string state)
    {
        done = state == "FINISHED";
        if (done) FinishQuestStep();
    }

    private bool done;

    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueFinished += OnDialogueFinished;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueFinished -= OnDialogueFinished;
    }

    private void OnDialogueFinished()
    {
        if (done) return;
        done = true;
        ChangeState("FINISHED");
        FinishQuestStep();

    }
}
