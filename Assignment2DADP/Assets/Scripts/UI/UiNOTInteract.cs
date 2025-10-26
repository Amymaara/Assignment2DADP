using UnityEngine;

public class UiNOTInteract : MonoBehaviour
{
    public CanvasGroup orderUICanvasGroup;

    void OnEnable()
    {
        orderUICanvasGroup.interactable = false;
        orderUICanvasGroup.blocksRaycasts = false;
    }
}
