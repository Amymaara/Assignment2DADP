using UnityEngine;

public class DoorUnlockManager : MonoBehaviour
{
    [Header("Doors")]
    [SerializeField] private DoorUnlock bedroomDoor;
    [SerializeField] private DoorUnlock potionDoor;
    [SerializeField] private DoorUnlock runeDoor;
    [SerializeField] private DoorUnlock crystalDoor;

    public void OpenBedroomDoor()
    {
        bedroomDoor.OpenDoor();
    }

    public void OpenPotionDoor()
    {
        potionDoor.OpenDoor();
    }

    public void OpenRuneDoor()
    {
        runeDoor.OpenDoor();
    }

    public void OpenCrystalDoor()
    {
        crystalDoor.OpenDoor();
    }
}
