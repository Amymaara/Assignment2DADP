using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class FinishedRuneObject : RuneInteractables
{

    [Tooltip("Order: Scribble (Wood, Stone, Bone) Star Moon Trifecta")]
    public Material[] Materials = new Material[12];

    public GameObject ThisRune;
    public ServeableItem servicableItem;

    public ItemSO Healing;
    public ItemSO Communication;
    public ItemSO Protection;



    private int GetIndex(Stamp stamp, RuneMaterial material)
    {
        return ((int)stamp * 3) + (int)material;
    }

    public void SetMaterial(Stamp stamp, RuneMaterial material)
    {
        int index = GetIndex(stamp, material);
        if (index >= 0 && index < Materials.Length && Materials[index] != null)
        {
            ThisRune.GetComponent<MeshRenderer>().material = Materials[index];
            this.material = material;
            this.stamp = stamp;

        }

        HandleServicableSetup(stamp, material);
    }

    private void HandleServicableSetup(Stamp stamp, RuneMaterial material)
    {
        
        servicableItem.enabled = false;

        if ((stamp == Stamp.Trifecta && material == RuneMaterial.Bone))
        {
            servicableItem.enabled = true;
            servicableItem.item = Healing;
            
        }

        if ((stamp == Stamp.Star && material == RuneMaterial.Stone))
        {
            servicableItem.enabled = true;
            servicableItem.item = Protection;

        }

        if ((stamp == Stamp.Moon && material == RuneMaterial.Wood))
        {
            servicableItem.enabled = true;
            servicableItem.item = Communication;

        }
    }

}
