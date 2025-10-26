using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;

// https://www.youtube.com/watch?v=15Bh5QiScbY
public class FlipCards : MonoBehaviour
{
    private bool flipped = false;

    public FPController controller;
    private Tween tween;
    public InputActionReference clickAction;
    private static int flippedCount = 0;


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
        AudioManager.PlaySound(AudioManager.SoundType.FLIPCARD, 0.1f);
        transform.DORotate(new(0, flipped ? 0f : 180f, 0), 0.25f);

        if (!flipped) return;
        
        flippedCount++;

        var tarot = CatTarotManager.Current;
        if (tarot == null || tarot.tarotCanvasRoot == null || !tarot.tarotCanvasRoot.activeInHierarchy)
        {
            return;
        }
       
        
        if (flippedCount >= 3)
        {
            if (tarot.continueButton)
            {
                tarot.continueButton.interactable = true;

                var nav = FindAnyObjectByType<UINavigationManager>();
                if (nav) nav.firstSelected = tarot.continueButton.gameObject;
                else
                {
                    EventSystem.current?.SetSelectedGameObject(null);
                    EventSystem.current?.SetSelectedGameObject(tarot.continueButton.gameObject);
                }
            }
        }
    }

    public void ResetState()
    {
        flipped = false;
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        flippedCount = 0;

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
