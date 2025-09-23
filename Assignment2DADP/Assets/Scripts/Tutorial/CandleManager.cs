using UnityEngine;

public class CandleManager : MonoBehaviour
{
    [SerializeField] private CandleSignposting[] candles;

    public static CandleManager Instance { get; internal set; }

    public void TurnOnPotionCandles()
    {
        candles[4].TurnOn();
        candles[5].TurnOn();
        candles[6].TurnOn();
        candles[7].TurnOn();
    }

    public void TurnOnRuneCandles()
    {

    }

    public void TurnOnCatCandles()
    {
        candles[0].TurnOn();
        candles[1].TurnOn();
        candles[2].TurnOn();
        candles[3].TurnOn();
    }

    public void TurnOnExploreCandles()
    {
        candles[8].TurnOn();
        candles[9].TurnOn();
        candles[10].TurnOn();
        candles[11].TurnOn();
    }
}
