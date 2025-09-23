using UnityEngine;
using System;

public class PotionCatInteract : MonoBehaviour
{
    public ItemSO requiredItem;
    public event Action OnServedCorrectly;
    public BelladonaAcceptsKnowledgePotion acceptQuest;


    public void SetOrder(ItemSO item)
    {
        requiredItem = item;
    }

    public bool TryServe(ServeableItem served)
    {
        if (served && served.item == requiredItem)
        {
            Debug.Log("Correct item give");
            OnServedCorrectly?.Invoke();
            UnityEngine.Object.FindFirstObjectByType<BelladonaAcceptsKnowledgePotion>()?.TryHandInPotion();
            //acceptQuest.TryHandInPotion();
            //Destroy(gameObject, 0.25f);
            return true;
        }
        else
        {
            Debug.Log("Wrong item");
            return false;
        }
    }

}
