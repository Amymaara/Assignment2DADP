using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PillarWorkstation : MonoBehaviour, IInteractable
{
    // if player drops a crystal on the pillar
    // or if player interacts (e) with pillar

    // set the current crystal on the totem to that crystal/material


    // set that current station to crystal full 

    // still gotta delete held item after

    public GameObject heldObject;
    public GameObject pillarCrystal;

    public Material amethyst;
    public Material rose;
    public Material lapis;

    public bool StationFilled = false;

    public CrystalBehaviours behaviours;

    public FPController controller;

    public enum CrystalMaterial
    {
        rose,
        lapis,
        amethyst
    }
    
    public CrystalMaterial Crystalmaterial;


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
                    Crystalmaterial = CrystalMaterial.rose;
                }
                else if (crystal.material == PillarCrystalInteractable.Material.Amethyst)
                {
                    pillarCrystal.gameObject.GetComponent<Renderer>().material = amethyst;
                    Crystalmaterial = CrystalMaterial.amethyst;
                }
                else if (crystal.material == PillarCrystalInteractable.Material.Lapis)
                {
                    pillarCrystal.gameObject.GetComponent<Renderer>().material = lapis;
                    Crystalmaterial = CrystalMaterial.lapis;
                }

                StationFilled = true;

                behaviours.CheckFilledStations();

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
