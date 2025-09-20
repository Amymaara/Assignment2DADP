using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // This script spawns a new ingredient on the shelf if the player picksit up after a short delay.
    // I still need to add a limit for the number of each type of ingredient in a scene so that it cant be spammed.

    // https://discussions.unity.com/t/respawn-a-pickup-using-instantiate/545091/5

    // https://www.youtube.com/watch?v=GtjoE1cA9Qs

    //https://www.youtube.com/watch?v=sUMEnIUeVro


    [System.Serializable]
    public class IngredientSlot
    {
        public string ingredientName;
        public GameObject prefab;
        public Transform spawnPoint;
        public float respawnDelay = 2f;
        public int maxSpawnedObjects = 4;
        [HideInInspector] public bool isRespawning = false;
        [HideInInspector] public List<GameObject> spawnedObjects = new List<GameObject>();
    }

    public IngredientSlot[] slots;

    private void Start()
    {
        foreach (var slot in slots)
        {
            Instantiate(slot.prefab, slot.spawnPoint.position, slot.spawnPoint.rotation);
        }
    }

    public void OnObjectLeftShelf(string ingredientName)
    {
        IngredientSlot slot = System.Array.Find(slots, s => s.ingredientName == ingredientName);
        if (slot != null && !slot.isRespawning)
        {
            Debug.Log("Trying to respawn " + ingredientName);
            StartCoroutine(Respawn(slot));
        }
    }

    private IEnumerator Respawn(IngredientSlot slot)
    {
        slot.isRespawning = true;
        Debug.Log("Respawning " + slot.ingredientName);
        yield return new WaitForSeconds(slot.respawnDelay);
        Spawn(slot);
        slot.isRespawning = false;
    }

    private void Spawn(IngredientSlot slot)
    {
        GameObject obj = Instantiate(slot.prefab, slot.spawnPoint.position, slot.spawnPoint.rotation);

        
        slot.spawnedObjects.Add(obj);

     
        if (slot.spawnedObjects.Count > slot.maxSpawnedObjects)
        {
            Destroy(slot.spawnedObjects[0]);
            slot.spawnedObjects.RemoveAt(0);
        }
    }
}

