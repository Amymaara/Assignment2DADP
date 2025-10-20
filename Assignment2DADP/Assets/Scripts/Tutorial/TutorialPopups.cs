using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class TutorialPopups : MonoBehaviour
{
    public UINavigationManager navigationManager;
    public InputManager inputManager;
    public GameObject heldObject;
    public RuneWorkstation workstation;
    public CrystalBehaviours crystalBehaviours;
    public PotionFillManager potionFillManager;


    public GameObject RunesPopUp;
    public GameObject CrystalsPopUp1;
    public GameObject CrystalsPopUp2;
    public GameObject PotionsPopUp1;
    public GameObject PotionsPopUp2;
    public GameObject PotionsPopUp3;




    public GameObject RunesButton;
    public GameObject CrystalsButton1;
    public GameObject CrystalsButton2;
    public GameObject PotionsButton1;
    public GameObject PotionsButton2;
    public GameObject PotionsButton3;



    void Start()
    {
        RunesPopUp.SetActive(false);
        CrystalsPopUp1.SetActive(false);
        CrystalsPopUp2.SetActive(false);
        PotionsPopUp1.SetActive(false);
        PotionsPopUp2.SetActive(false);
        PotionsPopUp3.SetActive(false);


    }

    public void PotionsPopup1()
    {
        PotionsPopUp1.SetActive(true);
        navigationManager.firstSelected = PotionsButton1;
        inputManager.SwitchToToolTip(PotionsButton1);

    }

    public void PotionsPopup1Close()
    {
        PotionsPopUp1.SetActive(false);
        inputManager.SwitchToGameplay();
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

    }

    public void PotionsPopup2()
    {
        PotionsPopUp2.SetActive(true);
        navigationManager.firstSelected = PotionsButton2;
        inputManager.SwitchToToolTip(PotionsButton2);

    }

    public void PotionsPopup2Close()
    {
        PotionsPopUp2.SetActive(false);
        potionFillManager.OnFullMeter();
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

    }

    public void PotionsPopup3()
    {
        StartCoroutine(WaitThenShowPotionPopup3());

    }

    
    public IEnumerator WaitThenShowPotionPopup3()
    {
        // Wait for 4 frames
        for (int i = 0; i < 4; i++)
        {
            yield return null; // waits 1 frame
        }
        PotionsPopUp3.SetActive(true);
        navigationManager.firstSelected = PotionsButton3;
        inputManager.SwitchToToolTip(PotionsButton3);
    }

    public void PotionsPopup3Close()
    {
        PotionsPopUp3.SetActive(false);
        inputManager.SwitchToGameplay();
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

    }

    public void RunePopup1()
    {
        RunesPopUp.SetActive(true);
        navigationManager.firstSelected = RunesButton;
        inputManager.SwitchToToolTip(RunesPopUp);
       

    }

    public void RunePopup1Close()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
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

    public void CrystalPopup1()
    {
        CrystalsPopUp1.SetActive(true);
        navigationManager.firstSelected = CrystalsButton1;
        inputManager.SwitchToToolTip(CrystalsPopUp1);


    }

    public void CrystalPopup1Close()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        CrystalsPopUp1.SetActive(false);
        inputManager.SwitchToGameplay();


    }

    public void CrystalPopup2()
    {
        CrystalsPopUp2.SetActive(true);
        navigationManager.firstSelected = CrystalsButton2;
        inputManager.SwitchToToolTip(CrystalsPopUp2);


    }

    public void CrystalPopup2Close()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        CrystalsPopUp2.SetActive(false);
        crystalBehaviours.CheckFilledStations();
       
    }

}
