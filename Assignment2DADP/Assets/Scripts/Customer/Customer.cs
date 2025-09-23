using UnityEngine;
using System;

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
        if (served && served.item == requiredItem)
        {
            Debug.Log("Correct item give");
            OnServedCorrectly?.Invoke();
            Destroy(gameObject, 0.25f);
            return true;
        }
        else
        {
            Debug.Log("Wrong item");
            return false;
        }
    }


}
