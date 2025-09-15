using UnityEngine;

public class PotionWorkstation : MonoBehaviour, IFillable, IInteractable
{
    public PotionFillManager fillManager;
    public PotionBehaviour potionBehaviour;
    public GameObject heldObject;
    public void OnFillStart()
    {
        Debug.Log("Trying To Fill");

        fillManager.StartSection();
    }

    public void OnFillStop()

    {
        Debug.Log("Stopping Fill");
        fillManager.StopSection();
    }

    public void Fill()
    {
        fillManager.GrowSection();

    }

    public void Interact()
    {

        Debug.Log("trying to interact");

        if (heldObject == null)
        {
            Debug.Log("held object is null");
            return;
        }
        if (heldObject.GetComponentInChildren<BottleInteractable>() == null)
        {
            Debug.Log("no bottle object");
            return;
        }
        else 
        {
            potionBehaviour.bottle();
        }

    }


}