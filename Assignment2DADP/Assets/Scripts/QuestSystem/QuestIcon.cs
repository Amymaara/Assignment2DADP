using UnityEngine;
// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
public class QuestIcon : MonoBehaviour
{
    [Header("Icons")]
    [SerializeField] private GameObject canStartIcon;
    [SerializeField] private GameObject requirementsNotMetToFinishIcon;
    [SerializeField] private GameObject canFinishIcon;
    [SerializeField] private GameObject finishedIcon;

    public void SetState(QuestState newState, bool startPoint, bool endPoint)
    {
        canFinishIcon.SetActive(false);
        requirementsNotMetToFinishIcon.SetActive(false);
        canStartIcon.SetActive(true);
        finishedIcon.SetActive(false);

        switch (newState)
        {
            case QuestState.CAN_START:
                if (startPoint) { canStartIcon.SetActive(true); }
                break;
            case QuestState.CAN_FINISH:
                if (endPoint) { canFinishIcon.SetActive(true); canStartIcon.SetActive(false); }
                break;
            case QuestState.FINISHED:
                if (endPoint) { finishedIcon.SetActive(true); canStartIcon.SetActive(false); AudioManager.PlaySound(AudioManager.SoundType.QUESTSUCCESS, 0.1f); }
                break;
            case QuestState.IN_PROGRESS:
                if (endPoint) { requirementsNotMetToFinishIcon.SetActive(true); canStartIcon.SetActive(false); }
                break;
            default:
                Debug.LogWarning("Quest State not recognised by switch statement for quest icon: " + newState);
                break;
        }
    }
}
