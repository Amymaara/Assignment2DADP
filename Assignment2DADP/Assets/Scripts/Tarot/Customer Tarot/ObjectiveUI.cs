using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectiveUI : MonoBehaviour
{
    public GameObject objectiveCardUI;
   /* public TMP_Text orderText;
    public TMP_Text itemText;
    //public TMP_Text recipeText;
   */
    public Image recipeImage;

    private CanvasGroup canvasgroup;

    void Start()
    {
        if(objectiveCardUI) objectiveCardUI.SetActive(false);
        SetRaycastBlocking(false);

        
    }

    // adds item name to orderUI
    /*  public void SetObjective(string itemID)
      {
          if (itemText) itemText.text = itemID;
          else Debug.LogWarning("item text not assigned");
      }
    */
    private void Awake()
    {
        if (objectiveCardUI)
        {
            canvasgroup = objectiveCardUI.GetComponent<CanvasGroup>();
            if (!canvasgroup) canvasgroup = objectiveCardUI.AddComponent<CanvasGroup>();    
        }
    }
    public void SetRecipe(Sprite recipeSprite)
    {
        if (recipeImage) recipeImage.sprite = recipeSprite;
    }

    public void ShowObjectiveCard()
    {
        objectiveCardUI.SetActive(true);
    }

    public void HideObjectiveCard()
    {
        objectiveCardUI.SetActive(false);
    }

    public void SetRaycastBlocking(bool on)
    {
        if (canvasgroup)
        {
            canvasgroup.blocksRaycasts = on;
            canvasgroup.interactable = on;
        }
    }
}
