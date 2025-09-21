using UnityEditor.SpeedTree.Importer;
using UnityEngine;
using UnityEngine.UI;

public class PotionFillManager : MonoBehaviour
{
    [Header("UI Setup")]
    public Transform fillContainer;       // Layout Group
    public GameObject fillSectionPrefab;  // UI Image prefab
    public float maxFillHeight = 1000f;    // maximum total height of fill
    public GameObject PotionBarCanvas;

    [Header("Current Ingredient")]
    public IngredientObject holding;
    public PotionInteractables ingredient;
    public FPController fpcontroller;

    [Header("MiniGame Setup")]
    public InputManager inputManager;
    public PotionBehaviour potionBehaviour;

    private float sagePercent = 0f;
    private float tearsPercent = 0f;
    private float bloodPercent = 0f;
    private float moonPercent = 0f;


    private float currentHeight = 0f;
    private GameObject currentSection;
    private RectTransform currentRect;
    private bool filling = false;

    public GameObject PotionLiquid;
    public Material[] materials;


    public void StartSection()
    {
        if (potionBehaviour.currentState == PotionBehaviour.CauldronState.Filling)
        {
            if (PotionBarCanvas.activeInHierarchy == false)
            {
                PotionBarCanvas.SetActive(true);
            }

            holding = fpcontroller.holdObject;
            if (holding == null) return;

            else
            {
                PotionInteractables temp = holding.GetComponent<PotionInteractables>();
                if (temp != null)
                {
                    ingredient = temp;
                }
            }
            if (ingredient == null) return;

            if (currentHeight >= maxFillHeight)
            {
                OnFullMeter();
                return;
            }


            currentSection = Instantiate(fillSectionPrefab, fillContainer);
            currentRect = currentSection.GetComponent<RectTransform>();
            currentRect.sizeDelta = new Vector2(currentRect.sizeDelta.x, 0f);


            Image img = currentSection.GetComponent<Image>();
            img.color = ingredient.fillColour;

            filling = true;
        }
        else return;
    }


    public void GrowSection()
    {
        if (!filling || currentRect == null) return;

        float growth = 200f * Time.deltaTime;
        float availableSpace = maxFillHeight - currentHeight;
        float newHeight = Mathf.Min(currentRect.sizeDelta.y + growth, availableSpace);

        currentRect.sizeDelta = new Vector2(currentRect.sizeDelta.x, newHeight);

        // check if bar is max height
        if (currentHeight + newHeight >= maxFillHeight)
        {
            StopSection();
            Debug.Log("Max Fill");
            OnFullMeter();
            filling = false;
        }

    }


    public void StopSection()
    {
        if (!filling || currentRect == null) return;
        float sectionHeight = currentRect.sizeDelta.y;
        currentHeight += sectionHeight;
        currentHeight = Mathf.Min(currentHeight, maxFillHeight);

        UpdateIngredients(sectionHeight);

        filling = false;
        currentSection = null;
        currentRect = null;
        ingredient = null;
        Destroy(fpcontroller.holdObject.gameObject);
    }

    public void UpdateIngredients(float bar)
    {
        switch (ingredient.material)
        {
            case PotionInteractables.PotionMaterial.cupidsTears:
                tearsPercent += bar;
                break;
            case PotionInteractables.PotionMaterial.dragonsBlood:
                bloodPercent += bar;
                break;
            case PotionInteractables.PotionMaterial.sage:
                sagePercent += bar;
                break;
            case PotionInteractables.PotionMaterial.moonWater:
                moonPercent += bar;
                break;

        }
    }

    public void OnFullMeter()
    {

        CheckRecipe();
        inputManager.SwitchToPotionMix();
        potionBehaviour.currentState = PotionBehaviour.CauldronState.Bottling;
        ResetMeter();

    }

    public void CheckRecipe()
    {
        Debug.Log("Tears = " + tearsPercent);
        Debug.Log("Sage = " + sagePercent);
        Debug.Log("Blood = " + bloodPercent);
        Debug.Log("Moon = " + moonPercent);

        if (480f < tearsPercent && tearsPercent < 520f
            && sagePercent < 270f && sagePercent > 230f
            && moonPercent < 270f && moonPercent > 230f)
        {
            potionBehaviour.recipe = PotionBehaviour.Recipe.Love;
            Debug.Log("Made a Love Potion");
            PotionLiquid.GetComponent<Renderer>().material = materials[0];

        }

        else if (sagePercent < 270f && sagePercent > 230f
            && bloodPercent < 770 && bloodPercent > 730)
        {
            potionBehaviour.recipe = PotionBehaviour.Recipe.Knowledge;
            Debug.Log("Made a Knowledge Potion");
            PotionLiquid.GetComponent<Renderer>().material = materials[1];
        }

        else
        {
            potionBehaviour.recipe = PotionBehaviour.Recipe.None;
            Debug.Log("No Potion Made");
            PotionLiquid.GetComponent<Renderer>().material = materials[2];

        }

        PotionLiquid.SetActive(true);
    }

    public void ResetMeter()
    {

        foreach (Transform child in fillContainer)
        {
            Destroy(child.gameObject);
        }
        currentHeight = 0f;
        sagePercent = 0f;
        moonPercent = 0f;
        tearsPercent = 0f;
        bloodPercent = 0f;

        PotionBarCanvas.SetActive(false);


    }

}