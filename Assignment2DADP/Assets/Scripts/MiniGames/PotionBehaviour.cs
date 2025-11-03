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
        Luck,
        Strength,
        Knowledge
    }

    public GameObject LovePotion;
    public GameObject KnowledgePotion;
    public GameObject NoRecipePotion;
    public GameObject LuckPotion;
    public GameObject StrengthPotion;

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
            controller.ForcePickUp(potion);
        }

        if (recipe == Recipe.Knowledge) 
        {
           GameObject potion = Instantiate(KnowledgePotion);
            controller.ForcePickUp(potion);
        }

        if (recipe == Recipe.Luck)
        {
            GameObject potion = Instantiate(LuckPotion);
            controller.ForcePickUp(potion);
        }

        if (recipe == Recipe.Strength)
        {
            GameObject potion = Instantiate(StrengthPotion);
            controller.ForcePickUp(potion);
        }

        if (recipe == Recipe.None) 
        {
            GameObject potion = Instantiate(NoRecipePotion);
            controller.ForcePickUp(potion);
        }

        currentState = CauldronState.Filling;
        LiquidCauldron.SetActive(false);
    }

   

}
