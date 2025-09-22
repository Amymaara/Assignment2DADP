using UnityEngine;

public class CandleManager : MonoBehaviour
{
    [SerializeField] private CandleSignposting[] candles;

    public static CandleManager Instance { get; internal set; }

    public void TurnOnPotionCandles()
    {

    }

    public void TurnOnRuneCandles()
    {

    }

    public void TurnOnCatCandles()
    {

    }

    public void TurnOnTestCandles()
    {
        candles[0].TurnOn();
        candles[1].TurnOn();
        candles[2].TurnOn();
        candles[3].TurnOn();
    }
}
