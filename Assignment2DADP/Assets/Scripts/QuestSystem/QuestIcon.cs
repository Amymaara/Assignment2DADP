using UnityEngine;

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
                if (endPoint) { finishedIcon.SetActive(true); canStartIcon.SetActive(false); }
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
