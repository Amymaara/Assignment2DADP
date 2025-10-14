using System.Reflection;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTarotReading : MonoBehaviour
{
    [Header("UI")]
    public Image front1;
    public Image front2;
    public Image front3;
    public Button continueButton;
    public Canvas tarotCanvas;

    [Header("Reset Card Flips")]
    public FlipCards card1;
    public FlipCards card2;
    public FlipCards card3;


    public void ShowEntry(DaySequence.Entry e, bool resetCardsToBack = true)
    {
        if (front1) front1.sprite = e.tarotCard1;
        if (front2) front2.sprite = e.tarotCard2;
        if (front3) front3.sprite = e.tarotCard3;

        if (resetCardsToBack) ResetCardsToBack();


    }

    void ResetCardsToBack()
    {
        var cards = new[] { card1, card2, card3 };
        foreach (var c in cards)
        {
            if (!c) continue;
            c.ResetState();
        }
    }

    void HideCanvas()
    {
        FindFirstObjectByType<TarotManager>()?.Close();
        gameObject.SetActive(false);
    }
}

  
