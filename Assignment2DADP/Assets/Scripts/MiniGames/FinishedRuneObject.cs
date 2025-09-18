using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class FinishedRuneObject : RuneInteractables
{ 

    [Tooltip("Order: Scribble (Wood, Stone, Bone) Star Moon Trifecta")]
    public Material[] Materials = new Material[12];

    public GameObject ThisRune;

    private int GetIndex( Stamp stamp, RuneMaterial material)
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
    }
}
