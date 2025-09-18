using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string ingredientName; 
    public SpawnManager manager;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("canPickUp"))
        {
            manager.OnObjectLeftShelf(ingredientName);
        }
    }
}
