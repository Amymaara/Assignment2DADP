using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

// https://www.youtube.com/watch?v=15Bh5QiScbY
public class FlipCards : MonoBehaviour
{
    private bool flipped = false;
    public FPController controller;
    public InputActionReference clickAction;

  
    private void Update()
    {
        if (clickAction.action.triggered)
        {
            Flip();
        }
    }

    private void Flip()
    {
        flipped = !flipped;
        transform.DORotate(new(0, flipped  ? 0f: 180f, 0), 0.25f);
        clickAction.action.Disable();

    }

    public void ResetState()
    {
        flipped = false;
    }

}
