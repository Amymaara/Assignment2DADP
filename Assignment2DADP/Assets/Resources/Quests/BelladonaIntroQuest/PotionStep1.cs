using UnityEngine;

public class PotionStep1 : QuestSteps
{
    [SerializeField] private TarotManager tarotManager;
    //chat helped

    public void CompleteFromTarot()
    {
        
        Debug.Log("[PotionStep1] Tarot spread opened — completing step.");
        FinishQuestStep();
    }

}
