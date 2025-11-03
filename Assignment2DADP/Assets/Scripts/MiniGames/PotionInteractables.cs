using UnityEngine;

public class PotionInteractables : IngredientObject
{

    public enum PotionMaterial
    {
        cupidsTears,
        sage,
        moonWater,
        dragonsBlood,
        mandrake
    }

    public enum Recipe
    {
        None,
        Knowledge,
        Luck,
        Strength,
        Love
    }

    public PotionMaterial material;
    public Recipe recipe;
    public Color fillColour;


}
