using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

// card flip / DOTween animation
// Title: EASILY Flip Cards in Unity in UNDER 3 MINUTES
// Author: The Code Otter
// Date Accessed: 26 October 2025
// Accessibility: https://www.youtube.com/watch?v=15Bh5QiScbY

// assisted by ChatGPT to get cards to flip individually. I managed to get all the cards to flip and have the animation, 
// however, I could not find out how to get it to flip individually.
 public class FlipCards : MonoBehaviour
{

    private bool flipped = false;

    public FPController controller;
    private Tween tween;
    public InputActionReference clickAction;

    private static int totalCardsFlipped = 0;
    private bool hasBeenFlipped = false;


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

        tween?.Kill();
        transform.DORotate(new(0, flipped ? 0f : 180f, 0), 0.25f);

        if (flipped && !hasBeenFlipped)
        {
            hasBeenFlipped = true;
            totalCardsFlipped++;

            var tarot = CatTarotManager.Current;
            if (tarot && tarot.tarotCanvasRoot && tarot.tarotCanvasRoot.activeInHierarchy)
            {
                if (totalCardsFlipped >= 3 && tarot.continueButton)
                {
                    tarot.continueButton.interactable = true;

                    var nav = FindAnyObjectByType<UINavigationManager>();
                    if (nav)
                        nav.firstSelected = tarot.continueButton.gameObject;
                    else
                    {
                        EventSystem.current?.SetSelectedGameObject(null);
                        EventSystem.current?.SetSelectedGameObject(tarot.continueButton.gameObject);
                    }
                }
            }
        }
        
        
    }

    public void ResetState()
    {
        flipped = false;
        hasBeenFlipped = false;
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);


        totalCardsFlipped = 0;

        if (clickAction != null)
        {
            clickAction.action.Enable();
        }
    }

    // this part was assisted by chatGPT
    private void OnPressStarted(InputAction.CallbackContext ctx)
    {
        /* if (!ctx.ReadValueAsButton()) return;
         Flip();
        */
      
        if (!ctx.ReadValueAsButton()) return;
        if (EventSystem.current == null) return;

        var selected = EventSystem.current.currentSelectedGameObject;
        if (selected && (selected == gameObject || selected.transform.IsChildOf(transform)))
        {
            Flip();
            return;
        }

        
        if (Pointer.current == null) return;
        Vector2 screenPos = Pointer.current.position.ReadValue();

        var pe = new PointerEventData(EventSystem.current) { position = screenPos };
        var hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pe, hits);

        if (hits.Count == 0) return;

        
        for (int i = 0; i < hits.Count; i++)
        {
            var go = hits[i].gameObject;
            var card = go.GetComponentInParent<FlipCards>();
            if (card != null)
            {
                
                if (card == this) Flip();
                return; 
            }
        }
    }


}


