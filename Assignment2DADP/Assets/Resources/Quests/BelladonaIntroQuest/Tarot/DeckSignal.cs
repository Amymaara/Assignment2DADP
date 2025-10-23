using UnityEngine;
using System;

public static class DeckSignal
{
    public static event Action OnDeckOpen;

    public static void DeckOpened()
    {
        OnDeckOpen?.Invoke();
    }
}
