
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SpawnManager : MonoBehaviour
{
    // This script spawns a new ingredient on the shelf if the player picksit up after a short delay.
    // I combined a few different tutorials/recources


    // Title: Respawn a pickup using Instantiate (Unity Discussion forum snippet)
    // Author: Unity community user(s)
    // Date Accessed: 15 September 2025
    //Availability:https://discussions.unity.com/t/respawn-a-pickup-using-instantiate/545091/5


    // Title: How to Make an Object Spawner in Unity (Unity C# Tutorial)
    //Author: Omogonix
    // Date Accessed: 15 September 2025
    // https://www.youtube.com/watch?v=GtjoE1cA9Qs




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
            StartCoroutine(Respawn(slot));
        }
    }

    private IEnumerator Respawn(IngredientSlot slot)
    {
        slot.isRespawning = true;
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

