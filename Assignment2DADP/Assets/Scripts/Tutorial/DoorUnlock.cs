using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public Animator animator;
    private bool isOpened = false;
   

    public void OpenDoor()
    {
        if (isOpened) return;   
        isOpened = true;
        animator.SetTrigger("IsOpen");
    }
}
