using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

// https://www.youtube.com/watch?v=15Bh5QiScbY
public class FlipCards : MonoBehaviour
{
    private bool flipped = false;
    public FPController controller;
    private Tween tween;
    public InputActionReference clickAction;


    void OnEnable()
    {
        if (clickAction != null)
        {
            clickAction.action.Enable();
            clickAction.action.performed += OnPressStarted;
        }
    }

    private void OnDisable()
    {
        if (clickAction != null)
        {
            clickAction.action.performed -= OnPressStarted;
            clickAction.action.Disable();
        }
    }


    private void Flip()
    {
        flipped = !flipped;
        transform.DORotate(new(0, flipped ? 0f : 180f, 0), 0.25f);

    }

    public void ResetState()
    {
        flipped = false;
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);

        if (clickAction != null)
        {
            clickAction.action.Enable();
        }
    }


    private void OnPressStarted(InputAction.CallbackContext ctx)
    {
        if (!ctx.ReadValueAsButton()) return; 
        Flip();
    }

}
