using UnityEngine;
// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
public class Quest
{
    public QuestInfoSO info;

    public QuestState state;

    private int currentQuestStepIndex;

    private QuestStepState[] questStepStates;

    public Quest(QuestInfoSO questInfo)
    {
        this.info = questInfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
        this.questStepStates = new QuestStepState[info.questStepPrefabs.Length];
        for (int i = 0; i < questStepStates.Length; i++)
        {
            questStepStates[i] = new QuestStepState();
        }
    }

    public Quest(QuestInfoSO questInfo, QuestState state, int currentQuestStepIndex, QuestStepState[] questStepStates) 
    {
        this.info = questInfo;
        this.state = state;
        this.currentQuestStepIndex = currentQuestStepIndex;
        this.questStepStates = questStepStates;

        if (this.questStepStates.Length != this.info.questStepPrefabs.Length)
        {
            Debug.LogWarning("Quest Steps Prefabs and Quest Step States are "
            + "of different lengths. This indicates something changed "
            + "with the QuestInfo and the saved data is now out of sync "
            + "Reset your data - as this might cause issues. QuestId: " + this.info.id);
            
        }
    }

    public void MoveToNextSTep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.questStepPrefabs.Length);
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPefab();
        if (questStepPrefab != null)
        {
            QuestSteps questSteps = Object.Instantiate<GameObject>(questStepPrefab, parentTransform)
                .GetComponent<QuestSteps>();
            questSteps.IntiatialiseQuestStep(info.id,currentQuestStepIndex, questStepStates[currentQuestStepIndex].state);
            Debug.Log("Spawned step");
        }
    }

    private GameObject GetCurrentQuestStepPefab()
    {
        GameObject questStepPrefab = null;
        if (CurrentStepExists())
        {
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogWarning("Step index out of range" + "there is no current step:QuestId" + info.id + ", stepIndex =" + currentQuestStepIndex);
        }
        return questStepPrefab;
    }
    
    public void StoreQuestStepState(QuestStepState questStepState, int stepIndex)
    {
        if (stepIndex < questStepStates.Length)
        {
            questStepStates[stepIndex].state = questStepState.state;
        }
        else
        {
            Debug.LogWarning("Tried to access quest step data but stepIndex was out of range:" + "QuestId = " + info.id + ", Step index" + stepIndex);
        }
    }

    public QuestData GetQuestData()
    {
        return new QuestData(state, currentQuestStepIndex, questStepStates);
    }
}
