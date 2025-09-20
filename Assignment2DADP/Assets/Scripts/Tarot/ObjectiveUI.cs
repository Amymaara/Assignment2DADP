using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public GameObject objectiveCardUI;
    public TMP_Text orderText;
    public TMP_Text itemText;
    public TMP_Text recipeText;

    void Start()
    {
        objectiveCardUI.SetActive(false);
    }

    // adds item name to orderUI
    public void SetObjective(string itemID)
    {
        if (itemText != null)
            itemText.text = itemID;

        else
            Debug.LogWarning("Order Text is not assigned in the inspector.");
    }

    public void SetRecipe(string recipe)
    {
        if(recipe != null)
            recipeText.text = recipe;
    }
    public void ShowObjectiveCard()
    {
        objectiveCardUI.SetActive(true);
    }

    public void HideObjectiveCard()
    {
        objectiveCardUI.SetActive(false);
    }

}
