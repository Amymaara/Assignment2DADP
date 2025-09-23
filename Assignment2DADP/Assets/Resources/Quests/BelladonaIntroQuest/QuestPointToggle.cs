using UnityEngine;

public class QuestPointToggle : MonoBehaviour
{
    [SerializeField] private GameObject questPointA;  
    [SerializeField] private GameObject questPointB;

    public void SwitchToFirst()
    {
        if (questPointB) questPointB.SetActive(false);
        if (questPointA) questPointA.SetActive(true);
    }

    public void SwitchToSecond()
    {
        if (questPointA) questPointA.SetActive(false);
        if (questPointB) questPointB.SetActive(true);
    }

    
}
