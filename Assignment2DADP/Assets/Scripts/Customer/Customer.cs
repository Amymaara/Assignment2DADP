using System;
using UnityEngine;
using static AudioManager;

// customer spawning help from this video
// Title: Unity- RPG Hero Diner - Customer Spawning
// Author: Design and Deploy
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=vI7VLNuyhpU&t=661s
public class Customer : MonoBehaviour
{
    public ItemSO requiredItem;
    public event Action OnServedCorrectly;

    public void SetOrder(ItemSO item)
    {
        requiredItem = item;
    }

    public bool TryServe(ServeableItem served)
    {
        Debug.Log($"[TryServe] CALLED. served={(served ? served.name : "NULL")}");

        if (served && served.item == requiredItem)
        {
            Debug.Log("Correct item give");
            AudioManager.PlaySound(SoundType.QUESTSUCCESS, 0.1f);
            OnServedCorrectly?.Invoke();
            Destroy(gameObject, 0.25f);
            return true;
        }
        else
        {
            AudioManager.PlaySound(SoundType.MINIGAMEFAIL, 0.1f);
            Debug.Log("Wrong item");
            return false;
        }
    }


}
