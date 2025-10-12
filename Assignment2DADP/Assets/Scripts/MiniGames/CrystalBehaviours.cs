using UnityEngine;

public class CrystalBehaviours : MonoBehaviour
{
    public PillarWorkstation NorthPillar;
    public PillarWorkstation EastPillar;
    public PillarWorkstation SouthPillar;
    public PillarWorkstation WestPillar;

    public CrystalWorkstation Table;

    

    public void CheckFilledStations()
    {
        if (NorthPillar.StationFilled && SouthPillar.StationFilled && EastPillar.StationFilled && WestPillar.StationFilled) 
        {
            //start minigame
            GetRecipe();
            Debug.Log("Start Minigame");
        }
    }
    
    public void GetRecipe()
    {
        if (NorthPillar.)
    }

}
