using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PotionBehaviour : MonoBehaviour
{

   public enum CauldronState
    {
        Filling,
        Bottling
    }

    public enum Recipe
    {
        None,
        Love,
        Knowledge
    }

    public GameObject LovePotion;
    public GameObject KnowledgePotion;
    public GameObject NoRecipePotion;

    public GameObject LiquidCauldron;

    public CauldronState currentState = CauldronState.Filling;
    public Recipe recipe;

    public FPController controller;

    public void bottle()
    {
        Destroy(controller.heldObject.gameObject);

        if (recipe == Recipe.Love) 
        {
            GameObject potion = Instantiate(LovePotion);
            controller.SpawnFullBottleInHand(LovePotion);
        }

        if (recipe == Recipe.Knowledge) 
        {
           GameObject potion = Instantiate(KnowledgePotion);
            controller.SpawnFullBottleInHand(KnowledgePotion);
        }

        if (recipe == Recipe.None) 
        {
            GameObject potion = Instantiate(NoRecipePotion);
            controller.SpawnFullBottleInHand(NoRecipePotion);
        }

        currentState = CauldronState.Filling;
        LiquidCauldron.SetActive(false);
    }

   

}
