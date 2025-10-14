using UnityEngine;

public class FrontCardFaces : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCardSprite(Sprite s)
    {
        if (spriteRenderer) spriteRenderer.sprite = s;
    }
}
