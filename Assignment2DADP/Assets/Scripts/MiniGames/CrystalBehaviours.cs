using UnityEngine;
using UnityEngine.InputSystem.XR;
using static PotionBehaviour;

public class CrystalBehaviours : MonoBehaviour
{
    public PillarWorkstation NorthPillar;
    public PillarWorkstation EastPillar;
    public PillarWorkstation SouthPillar;
    public PillarWorkstation WestPillar;

    public CrystalWorkstation Table;

    public InputManager inputManager;

    public FPController controller;

    public GameObject PeaceCrystal;
    public GameObject HappinessCrystal;
    public GameObject CleansingCrystal;
    public GameObject NoCrystal;

    public TutorialPopups popups;

    int interactionCount = 0;
    int minigameCount = 0;
    private void Start()
    {
        minigameCount = 0;
        interactionCount = 0;
    }

    public enum Recipe
    {
        None,
        Peace,
        Happiness,
        Cleansing
    }

    public Recipe CrystalRecipe;

    
    public void FirstInteractCheck()
    {
        if (interactionCount == 0)
        {
            popups.CrystalPopup1();
            interactionCount++;
        }
    }

    public void CheckFilledStations()
    {
      
        if (NorthPillar.StationFilled && SouthPillar.StationFilled && EastPillar.StationFilled && WestPillar.StationFilled && Table.StationFilled) 
        {
            if (minigameCount == 0)
            {
                popups.CrystalPopup2();
                minigameCount++;
            }
            else
            {
                GetRecipe();
                //start minigame
                inputManager.SwitchToCrystal();
                Debug.Log("Start Minigame");
            }
        }
    }
    
    public void GetRecipe()
    {
        if (NorthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.amethyst && SouthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.rose
            && EastPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.amethyst && WestPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.lapis)
        {
            // cleasing recipe
            CrystalRecipe = Recipe.Cleansing;
        }
        else if (NorthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.rose && SouthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.rose
            && EastPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.lapis && WestPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.lapis)
        {
            // happiness recipe
            CrystalRecipe = Recipe.Happiness;
        }
        else if (NorthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.lapis && SouthPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.amethyst
            && EastPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.amethyst && WestPillar.Crystalmaterial == PillarWorkstation.CrystalMaterial.rose)
        {
            // peace recipe
            CrystalRecipe = Recipe.Peace;
        }
        else
        {
            // no recipe
            CrystalRecipe = Recipe.None;
        }
    }

    public void ResetWorkstations()
    {
        NorthPillar.StationFilled = false;
        SouthPillar.StationFilled = false;
        EastPillar.StationFilled = false;
        WestPillar.StationFilled=false;
        Table.StationFilled = false;

        NorthPillar.pillarCrystal.SetActive(false);
        SouthPillar.pillarCrystal.SetActive(false);
        EastPillar.pillarCrystal.SetActive(false);
        WestPillar.pillarCrystal.SetActive(false);
        Table.tableCrystal.SetActive(false);

        
    }

    public void GetCrystal()
    {
        

        if (CrystalRecipe == Recipe.Peace)
        {
            GameObject crystal = Instantiate(PeaceCrystal);
            controller.ForcePickUp(crystal);
        }
        else if (CrystalRecipe == Recipe.Happiness)
        {
            GameObject crystal = Instantiate(HappinessCrystal);
            controller.ForcePickUp(crystal);
        }
        else if (CrystalRecipe == Recipe.Cleansing)
        {
            GameObject crystal = Instantiate(CleansingCrystal);
            controller.ForcePickUp(crystal);
        }
        else
        {
            GameObject crystal = Instantiate(NoCrystal);
            controller.ForcePickUp(crystal);
        }

    }
}
