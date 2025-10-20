using UnityEngine;

public class TutorialPopups : MonoBehaviour
{
    public UINavigationManager navigationManager;
    public InputManager inputManager;
    public GameObject heldObject;
    public RuneWorkstation workstation;



    public GameObject RunesPopUp;




    public GameObject RunesButton;



    void Start()
    {
        RunesPopUp.SetActive(false);
      
    }


    public void RunePopup1()
    {
        RunesPopUp.SetActive(true);
        navigationManager.firstSelected = RunesButton;
        inputManager.SwitchToToolTip(RunesPopUp);
       

    }

    public void RunePopup1Close()
    {
        RunesPopUp.SetActive(false);

        RuneInteractables[] runeBase = heldObject.GetComponentsInChildren<RuneInteractables>();

        if (runeBase.Length > 0)
        {
            foreach (RuneInteractables rune in runeBase)
            {
                if (!rune.finishedProduct)
                {
                    workstation.Interact();
                }
            }
        }
        else
        {
            inputManager.SwitchToGameplay();
        }
    }

}
