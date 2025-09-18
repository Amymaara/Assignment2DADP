using System.Collections;

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

        [HideInInspector] public bool isRespawning = false;
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
            Debug.Log("Trying To Respawning");
            StartCoroutine(Respawn(slot));
        }
    }

    private IEnumerator Respawn(IngredientSlot slot)
    {
        slot.isRespawning = true;
        Debug.Log("Respawning");
        yield return new WaitForSeconds(slot.respawnDelay);
        Instantiate(slot.prefab, slot.spawnPoint.position, slot.spawnPoint.rotation);
        slot.isRespawning = false;
    }
}
