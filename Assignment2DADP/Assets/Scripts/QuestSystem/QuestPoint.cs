using UnityEngine;


[RequireComponent (typeof(SphereCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    private bool playerIsNear = false;
    private string questId;
    private QuestState currentQuestState;

    private void Awake()
    {
       
        questId = questInfoForPoint.id;
    }

    private void OnEnable()
    {
       
        var mgr = GameEventsManager.instance;
        if (mgr == null) { Debug.LogError("[QP] GameEventsManager not ready"); return; }
        
       GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
       GameEventsManager.instance.inputEvents.onInteractPressed += InteractPressed;

        Debug.Log("[QP] Enabled: Waiting for player + interact");

    }
    private void OnDisable()
    {
       GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
       GameEventsManager.instance.inputEvents.onInteractPressed -= InteractPressed;

        Debug.Log("[QP] Disabled");
    }

    private void InteractPressed()
    {
        Debug.Log("[QP] Interact pressed");
        if (!playerIsNear)
        {
            return;
        }

        GameEventsManager.instance.questEvents.StartQuest(questId);
        GameEventsManager.instance.questEvents.AdvanceQuest(questId);
        GameEventsManager.instance.questEvents.FinishQuest(questId);
    }
    private void QuestStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("[QP] Quest with id:" + questId + "updated to state:" + currentQuestState);
        }
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = true;
            Debug.Log("[QP] Player entered trigger");
        }
    }
    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = false;
            Debug.Log("[QP] Player exited trigger");
        }
    }
}
