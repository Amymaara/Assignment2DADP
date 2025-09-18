using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class RuneBehaviour : MonoBehaviour
{
    [Header("Stamps")]
    public GameObject star;
    public GameObject moon;
    public GameObject trifecta;
    public GameObject canvas;
    public GameObject firstButton;

    [Header("Player Movement")]
    public FPController controller;
    public GameObject cursor;
    public GameObject playerLine;
    public InputManager inputManager;
    public RuneDraw drawing;

    [Header("Runes")]
    public RuneInteractables inputProduct;
    public GameObject outPutProduct;
    public GameObject runeOnTable;
    public RuneWorkstation workstation;
    public Material wood;
    public Material bone;
    public Material stone;

    public GameObject StarRune;
    public GameObject MoonRune;
    public GameObject TrifectaRune;
   

    //public Material Star;
    //public Material Trifecta;
    //public Material Moon;
    //public GameObject ScribbleRune;

    public GameObject finishedRunePrefab;


    public void OnRuneTableInteract(RuneInteractables input)
    {

        if (input != null)
        {
            inputProduct = input;
            EditRuneOnTable();
        }

        drawing.canDraw = false;
        inputManager.SwitchToRuneDrawing();
        EventSystem.current.SetSelectedGameObject(firstButton);
        canvas.SetActive(true);
        cursor.SetActive(false);
    }

    private void EditRuneOnTable()
    {

        if (inputProduct.material == RuneInteractables.RuneMaterial.Wood)
        {
            runeOnTable.gameObject.GetComponent<Renderer>().material = wood;
        }
        else if (inputProduct.material == RuneInteractables.RuneMaterial.Stone)
        {
            runeOnTable.gameObject.GetComponent<Renderer>().material = stone;
        }
        else if (inputProduct.material == RuneInteractables.RuneMaterial.Bone)
        {
            runeOnTable.gameObject.GetComponent<Renderer>().material = bone;
        }
    }

    public void OnStarButton()
    {
        star.SetActive(true);
        cursor.SetActive(true);
        playerLine.SetActive(true);
        canvas.SetActive(false);
        workstation.playerRune.stamp = RuneInteractables.Stamp.Star;
        //workstation.playerRune.secondMesh.SetActive(true);
        //workstation.playerRune.secondMesh.GetComponent<Renderer>().material = Star;
        drawing.canDraw = true;

    }

    public void OnMoonButton()
    {
        moon.SetActive(true);
        cursor.SetActive(true);
        playerLine.SetActive(true);
        canvas.SetActive(false);
        workstation.playerRune.stamp = RuneInteractables.Stamp.Moon;
        //workstation.playerRune.secondMesh.SetActive(true);
        //workstation.playerRune.secondMesh.GetComponent<Renderer>().material = Moon;
        drawing.canDraw = true;
    }

    public void OnTrifectaButton()
    {
        trifecta.SetActive(true);
        cursor.SetActive(true);
        playerLine.SetActive(true);
        canvas.SetActive(false);
        workstation.playerRune.stamp = RuneInteractables.Stamp.Trifecta;
        //workstation.playerRune.secondMesh.SetActive(true);
        //workstation.playerRune.secondMesh.GetComponent<Renderer>().material = Trifecta;
        drawing.canDraw = true;
    }

    public void Outcome(float accuracy)
    {
        RuneInteractables finishedRune = finishedRunePrefab.GetComponent<RuneInteractables>();

        if (accuracy < 0.77f)
        {

            // play fail effects / sounds once minigame closes?
            finishedRune.material = 

        }
        else
        {
            //play pass effects/sounds

            if (workstation.playerRune.stamp == RuneInteractables.Stamp.Star)
            {
                
            }
            else if (workstation.playerRune.stamp == RuneInteractables.Stamp.Moon)
            {

            }
            else if (workstation.playerRune.stamp == RuneInteractables.Stamp.Trifecta)
            {

            }

            
        }
    }

}
