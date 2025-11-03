using UnityEngine;

public class CandleManager : MonoBehaviour
{
    [SerializeField] private CandleSignposting[] candles;

    public static CandleManager Instance { get; internal set; }


    private void Start()
    {
       TurnOnRoomCandles();
    }

    public void TurnOnRoomCandles()
    {
        candles[0].TurnOn();
        candles[1].TurnOn();
        candles[2].TurnOn();
        candles[3].TurnOn();
        candles[4].TurnOn();
        candles[5].TurnOn();
        candles[6].TurnOn();
        candles[7].TurnOn();
        candles[8].TurnOn();
        candles[9].TurnOn();
        candles[10].TurnOn();
        candles[11].TurnOn();
        candles[12].TurnOn();
        candles[13].TurnOn();
        candles[14].TurnOn();
        candles[15].TurnOn();
    }

    public void TurnOffRoomCandles()
    {
        candles[0].TurnOff();
        candles[1].TurnOff();
        candles[2].TurnOff();
        candles[3].TurnOff();
        candles[4].TurnOff();
        candles[5].TurnOff();
        candles[6].TurnOff();
        candles[7].TurnOff();
        candles[8].TurnOff();
        candles[9].TurnOff();
        candles[10].TurnOff();
        candles[11].TurnOff();
        candles[12].TurnOff();
        candles[13].TurnOff();
        candles[14].TurnOff();
        candles[15].TurnOff();
    }
    public void TurnOnFrontCandles()
    {
        candles[16].TurnOn();
        candles[17].TurnOn();
        candles[18].TurnOn();
        candles[19].TurnOn();
        candles[20].TurnOn();
        candles[21].TurnOn();
        candles[22].TurnOn();
        candles[23].TurnOn();
        candles[24].TurnOn();
        candles[25].TurnOn();
        candles[26].TurnOn();
        candles[27].TurnOn();
        candles[28].TurnOn();
        candles[29].TurnOn();
        candles[30].TurnOn();
        candles[31].TurnOn();
        candles[32].TurnOn();
        candles[33].TurnOn();
        candles[34].TurnOn();
        candles[35].TurnOn();
        candles[36].TurnOn();
        candles[37].TurnOn();
        candles[38].TurnOn();
        candles[39].TurnOn();
    }
    public void TurnOffFrontCandles()
    {
        candles[16].TurnOff();
        candles[17].TurnOff();
        candles[18].TurnOff();
        candles[19].TurnOff();
        candles[20].TurnOff();
        candles[21].TurnOff();
        candles[22].TurnOff();
        candles[23].TurnOff();
        candles[24].TurnOff();
        candles[25].TurnOff();
        candles[26].TurnOff();
        candles[27].TurnOff();
        candles[28].TurnOff();
        candles[29].TurnOff();
        candles[30].TurnOff();
        candles[31].TurnOff();
        candles[32].TurnOff();
        candles[33].TurnOff();
        candles[34].TurnOff();
        candles[35].TurnOff();
        candles[36].TurnOff();
        candles[37].TurnOff();
        candles[38].TurnOff();
        candles[39].TurnOff();
    }

    public void TurnOnPotionCandles()
    {
        candles[40].TurnOn();
        candles[41].TurnOn();
        candles[42].TurnOn();
        candles[43].TurnOn();
        candles[44].TurnOn();
        candles[45].TurnOn();
        candles[46].TurnOn();
        candles[47].TurnOn();
        candles[48].TurnOn();
        candles[49].TurnOn();
        candles[50].TurnOn();
        candles[51].TurnOn();
        candles[52].TurnOn();
        candles[53].TurnOn();
        candles[54].TurnOn();
        candles[55].TurnOn();
        candles[56].TurnOn();
        candles[57].TurnOn();
        candles[58].TurnOn();
        candles[59].TurnOn();
        candles[60].TurnOn();
        candles[61].TurnOn();
        candles[62].TurnOn();
    }

    public void TurnOffPotionCandles()
    {
        candles[40].TurnOff();
        candles[41].TurnOff();
        candles[42].TurnOff();
        candles[43].TurnOff();
        candles[44].TurnOff();
        candles[45].TurnOff();
        candles[46].TurnOff();
        candles[47].TurnOff();
        candles[48].TurnOff();
        candles[49].TurnOff();
        candles[50].TurnOff();
        candles[51].TurnOff();
        candles[52].TurnOff();
        candles[53].TurnOff();
        candles[54].TurnOff();
        candles[55].TurnOff();
        candles[56].TurnOff();
        candles[57].TurnOff();
        candles[58].TurnOff();
        candles[59].TurnOff();
        candles[60].TurnOff();
        candles[61].TurnOff();
        candles[62].TurnOff();
    }

    public void TurnOnRuneCandles()
    {
        candles[63].TurnOn();
        candles[64].TurnOn();
        candles[65].TurnOn();
        candles[66].TurnOn();
        candles[67].TurnOn();
        candles[68].TurnOn();
        candles[69].TurnOn();
        candles[70].TurnOn();
        candles[71].TurnOn();
        candles[72].TurnOn();
        candles[73].TurnOn();
        candles[74].TurnOn();
        candles[75].TurnOn();
        candles[76].TurnOn();
        candles[77].TurnOn();
        candles[78].TurnOn();
        candles[79].TurnOn();
        candles[80].TurnOn();
        candles[81].TurnOn();
        candles[82].TurnOn();
        candles[83].TurnOn();
        candles[84].TurnOn();
        candles[85].TurnOn();
        candles[86].TurnOn();
    }

    public void TurnOffRuneCandles()
    {
        candles[63].TurnOff();
        candles[64].TurnOff();
        candles[65].TurnOff();
        candles[66].TurnOff();
        candles[67].TurnOff();
        candles[68].TurnOff();
        candles[69].TurnOff();
        candles[70].TurnOff();
        candles[71].TurnOff();
        candles[72].TurnOff();
        candles[73].TurnOff();
        candles[74].TurnOff();
        candles[75].TurnOff();
        candles[76].TurnOff();
        candles[77].TurnOff();
        candles[78].TurnOff();
        candles[79].TurnOff();
        candles[80].TurnOff();
        candles[81].TurnOff();
        candles[82].TurnOff();
        candles[83].TurnOff();
        candles[84].TurnOff();
        candles[85].TurnOff();
        candles[86].TurnOff();
    }

    public void TurnOnCrystalCandles()
    {
        candles[87].TurnOn();
        candles[88].TurnOn();
        candles[89].TurnOn();
        candles[90].TurnOn();
        candles[91].TurnOn();
        candles[92].TurnOn();
        candles[93].TurnOn();
        candles[94].TurnOn();
        candles[95].TurnOn();
        candles[96].TurnOn();
        candles[97].TurnOn();
        candles[98].TurnOn();
        candles[99].TurnOn();
        candles[100].TurnOn();
        candles[101].TurnOn();
        candles[102].TurnOn();
        candles[103].TurnOn();
        candles[104].TurnOn();
        candles[105].TurnOn();
        candles[106].TurnOn();
        candles[107].TurnOn();
        candles[108].TurnOn();
        candles[109].TurnOn();
        candles[110].TurnOn();
    }

    public void TurnOffCrystalCandles()
    {
        candles[87].TurnOff();
        candles[88].TurnOff();
        candles[89].TurnOff();
        candles[90].TurnOff();
        candles[91].TurnOff();
        candles[92].TurnOff();
        candles[93].TurnOff();
        candles[94].TurnOff();
        candles[95].TurnOff();
        candles[96].TurnOff();
        candles[97].TurnOff();
        candles[98].TurnOff();
        candles[99].TurnOff();
        candles[100].TurnOff();
        candles[101].TurnOff();
        candles[102].TurnOff();
        candles[103].TurnOff();
        candles[104].TurnOff();
        candles[105].TurnOff();
        candles[106].TurnOff();
        candles[107].TurnOff();
        candles[108].TurnOff();
        candles[109].TurnOff();
        candles[110].TurnOff();
    }

    

}
