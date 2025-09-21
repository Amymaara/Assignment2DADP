using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CandleSignposting : MonoBehaviour
{

    [SerializeField] private GameObject flameFx;
    private bool isOn = false;

    private void Start()
    {
      flameFx.SetActive(false);
    }

    public void TurnOn()
    {
        isOn = true;
        flameFx.SetActive(true);
    }

    public void TurnOff()
    {
        isOn = false;
        flameFx.SetActive(false);
    }

}
