using System.Linq.Expressions;
using UnityEngine;


[RequireComponent (typeof(SphereCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private string dialogueKnotName;
    
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool endPoint = true;

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


    }
    private void OnDisable()
    {
       GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
       GameEventsManager.instance.inputEvents.onInteractPressed -= InteractPressed;
    }

    private void InteractPressed(InputEventsContext inputEventsContext)
    {
        if (!playerIsNear || !inputEventsContext.Equals(InputEventsContext.DEFAULT))
        {
            return;
        }

        if (!dialogueKnotName.Equals(""))
        {
            GameEventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
        }

        else
        {
            if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
            {
                GameEventsManager.instance.questEvents.StartQuest(questId);
            }

            else if (currentQuestState.Equals(QuestState.CAN_FINISH) && endPoint)
            {
                GameEventsManager.instance.questEvents.FinishQuest(questId);
            }

        }


        
    }
    private void QuestStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
        }
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }
    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
