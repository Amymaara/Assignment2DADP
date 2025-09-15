using UnityEngine;

public class BottleInteractable : MonoBehaviour
{
    public enum BottleState
    {
       Empty,
       Full
    }

    public enum Recipe
    {
        None,
        Knowledge,
        Love
    }

    public Recipe recipe = Recipe.None;
    public BottleState state = BottleState.Empty;
}
