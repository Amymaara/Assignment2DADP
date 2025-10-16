using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cursor;
    public CameraManager manager;
    public GameObject RuneMinigame;
    public GameObject pauseMenu;
    public GameObject tarot;
    public GameObject crystals;
    //public GameObject ToolTipsCanvas;
    //public GameObject DialogueCanvas;
    public GameObject PotionWorldSpaceCanvas;
    public GameObject potionMix;

    private void Start()
    {
        //SwitchToUI();
        //ToolTipsCanvas.SetActive(true);
        SwitchToGameplay();
        PotionWorldSpaceCanvas.SetActive(false);

    }

    public void SwitchToGameplay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RuneMinigame.SetActive(false);
        potionMix.SetActive(false);
        crystals.SetActive(false);
        cursor.SetActive(false);
        pauseMenu.SetActive(false);
        player.SetActive(true);
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        manager.SwitchToPlayerCam();
    }

    public void SwitchToUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.SetActive(true);
        pauseMenu.SetActive(true);
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
    }


    public void SwitchToRuneDrawing()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PotionWorldSpaceCanvas.SetActive(false);
        RuneMinigame.SetActive(true);
        player.SetActive(false);
        cursor.SetActive(true);
        manager.SwitchToRuneCam();
    }

    public void SwitchToPotionMix()
    {
        potionMix.SetActive(true);
        manager.SwitchToPotionCam();
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Potions"); //make a potion control map

    }

    public void SwitchToCrystal()
    {
        crystals.SetActive(true);
        manager.SwitchToCrystalCam();
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Crystals");
    }

    public void OnMenuExit(InputAction.CallbackContext context)
    {
        SwitchToGameplay();
        /*
        foreach (Canvas canvas in popUpCanvas.GetComponentsInChildren<Canvas>())
        {
            canvas.gameObject.SetActive(false);
        }
        */
    }

    
}

