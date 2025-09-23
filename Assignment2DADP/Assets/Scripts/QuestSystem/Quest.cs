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

    public Quest(QuestInfoSO questinfo)
    {
        this.info = questinfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
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
            questSteps.IntiatialiseQuestStep(info.id);
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
    
}
