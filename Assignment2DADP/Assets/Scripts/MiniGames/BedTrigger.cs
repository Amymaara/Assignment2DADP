using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour,IInteractable
{
    public bool canInteract;

    void Start()
    {
        canInteract = false;
    }

    public void Interact()
    {
        if (canInteract)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
}
