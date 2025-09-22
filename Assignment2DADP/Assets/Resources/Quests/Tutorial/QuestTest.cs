using UnityEngine;

public class QuestTest : QuestSteps
{
    [Header("Settings")]
    public float autoCompleteDelay = 5f;
    [SerializeField] private CandleManager candleManager;


    private void Start()
    {
        Debug.Log("[SimpleQuestStep] Started step, will finish after delay...");
        Invoke(nameof(FinishStep), autoCompleteDelay);

       
         // assisted by chat to get this to work in scriptable object
        if (candleManager == null)
        {
            var mgrRoot = GameObject.Find("Managers");
            if (mgrRoot != null)
                candleManager = mgrRoot.GetComponentInChildren<CandleManager>(true); 
        }

        candleManager.TurnOnTestCandles();
    }

    void FinishStep()
    {
        Debug.Log("[SimpleQuestStep] Completing step now!");
        FinishQuestStep();  
    }
}
