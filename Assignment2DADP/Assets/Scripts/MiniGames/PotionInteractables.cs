using UnityEngine;

public class PotionInteractables : IngredientObject
{

    public enum PotionMaterial
    {
        cupidsTears,
        sage,
        moonWater,
        dragonsBlood
    }

    public enum Recipe
    {
        None,
        Knowledge,
        Love
    }

    public PotionMaterial material;
    public Recipe recipe;
    public Color fillColour;


}
