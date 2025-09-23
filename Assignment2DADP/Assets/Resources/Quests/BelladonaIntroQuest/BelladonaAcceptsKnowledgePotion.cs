using UnityEngine;

public class BelladonaAcceptsKnowledgePotion : MonoBehaviour
{
    [SerializeField] ItemSO knowledgePotion;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var served = other.GetComponentInChildren<ServeableItem>();
        if (served && served.item == knowledgePotion)
        {
          Accept(served);
        }
    }

    private void Accept(ServeableItem served)
    {
        Debug.Log("Belladona accepts potion");
        if (served && served.item == knowledgePotion) Destroy(gameObject);

        var step = FindAnyObjectByType<PotionStep2>();
        if (step != null) step.CompleteFromBelladona();
    }
}

