using UnityEngine;

public class IngredientObject : MonoBehaviour
{
    public bool finishedProduct = false;

    // this is gonna be to check which stations the item can be used at
    public enum Station
    {
        Runes,
        Potions,
        Cat
    }


    public Station station;


}
