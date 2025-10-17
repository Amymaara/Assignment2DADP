using UnityEngine;

[CreateAssetMenu(menuName = "TarotPreset")]
public class TarotPreset : ScriptableObject
{
    [Header("Card reading")]
    public Sprite card1;
    public Sprite card2;
    public Sprite card3;

    [Header("Order")]
    public ItemSO order;
    public Sprite recipeCard;
}
