using UnityEngine;

public class CrystalWorkstation : MonoBehaviour, IInteractable
{
  

    public GameObject heldObject;

    public GameObject tableCrystal;

    public bool StationFilled = false;

    public CrystalBehaviours behaviours;

    public FPController controller;

    public void Interact()
    {

        Debug.Log("trying to interact");

        if (heldObject == null)
        {
            Debug.Log("held object is null");
            return;
        }
        if (heldObject.GetComponentInChildren<CrystalInteractable>() != null)
        {
            CrystalInteractable[] heldcrystal = heldObject.GetComponentsInChildren<CrystalInteractable>();

            foreach (CrystalInteractable crystal in heldcrystal)
            {
                if (crystal.material == CrystalInteractable.Material.None)
                {
                    tableCrystal.SetActive(true);

                    StationFilled = true;
                    behaviours.CheckFilledStations();

                }

                Destroy(controller.heldObject.gameObject);

            }
            return;
        }
        else
        {
            return;
        }

    }
}
