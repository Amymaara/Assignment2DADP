using UnityEngine;

public class PillarWorkstation : MonoBehaviour, IInteractable
{
    // if player drops a crystal on the pillar
    // or if player interacts (e) with pillar

    // set the current crystal on the totem to that crystal/material


    // set that current station to crystal full 

    // still gotta delete helpd item after

    public GameObject heldObject;
    public GameObject pillarCrystal;

    public Material amethyst;
    public Material rose;
    public Material lapis;

    public bool StationFilled = false;


    public void Interact()
    {

        Debug.Log("trying to interact");

        if (heldObject == null)
        {
            Debug.Log("held object is null");
            return;
        }
        if (heldObject.GetComponentInChildren<PillarCrystalInteractable>() != null)
        {
            PillarCrystalInteractable[] heldcrystal = heldObject.GetComponentsInChildren<PillarCrystalInteractable>();

            foreach (PillarCrystalInteractable crystal in heldcrystal)
            {
                pillarCrystal.SetActive(true);

                if (crystal.material == PillarCrystalInteractable.Material.Rose)
                {
                    pillarCrystal.gameObject.GetComponent<Renderer>().material = rose;
                }
                else if (crystal.material == PillarCrystalInteractable.Material.Amethyst)
                {
                    pillarCrystal.gameObject.GetComponent<Renderer>().material = amethyst;
                }
                else if (crystal.material == PillarCrystalInteractable.Material.Lapis)
                {
                    pillarCrystal.gameObject.GetComponent<Renderer>().material = lapis;
                }

                StationFilled = true;

            }
            return;
        }
        else
        {
            return;
        }

    }

}
