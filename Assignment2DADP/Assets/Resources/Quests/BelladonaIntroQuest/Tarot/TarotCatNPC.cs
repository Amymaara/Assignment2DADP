using UnityEngine;

public class TarotCatNPC : QuestSteps

{
   
    private bool done;

    private void OnEnable()
    {
        DeckSignal.OnDeckOpen += HandleDeckOpened;
      
    }

    private void OnDisable()
    {
        DeckSignal.OnDeckOpen -= HandleDeckOpened;
      
    }
    protected override void SetQuestStepState(string state)
    {
        done = state == "FINISH";
        if (done) FinishQuestStep();
    }

    private void HandleDeckOpened()
    {
        if (done) return;
        done = true;

        FinishQuestStep();
    }

    
}
