using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static AudioManager;

public class PauseMenu : MonoBehaviour
{
    public InputManager inputManager;
    
    public GameObject firstButton;
    public GameObject ControlsButton;
    public GameObject RunesButton;
    public GameObject PotionsButton;
    public GameObject CrystalButton;
    public GameObject VolumeSlider;
    public UINavigationManager navigationManager;

    public GameObject Settings;
    

    [Header("Tooltips")]
    public GameObject ControlsToolTip;
    public GameObject CrystalsToolTip;
    public GameObject RunesToolTip;
    public GameObject PotionsToolTip;

    private GameObject[] tooltips;
    private int currentTooltipIndex = 0;

    private void Awake()
    {
        tooltips = new GameObject[] { ControlsToolTip, CrystalsToolTip, RunesToolTip, PotionsToolTip };
    }

    private void OnEnable()
    {
        //EventSystem.current.SetSelectedGameObject(firstButton);
        navigationManager.firstSelected = firstButton;
        ControlsToolTip.SetActive(false);
        RunesToolTip.SetActive(false);
        PotionsToolTip.SetActive(false);
        CrystalsToolTip.SetActive(false);
        Settings.SetActive(false);
        FindFirstObjectByType<TimerBar>()?.PauseTimer();
        Time.timeScale = 0f;

    }


    /*
    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (ControlsToolTip.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(ControlsButton.gameObject);
            }
            else if (PotionsToolTip.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(PotionsButton.gameObject);
            }
            else if (RunesToolTip.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(RunesButton.gameObject);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
            }
                
        }
    }
    */

    public void OnResume()
    {
        FindFirstObjectByType<TimerBar>()?.ResumeTimer();
        Time.timeScale = 1f;
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        inputManager.SwitchToGameplay();
    }

    public void OnControls()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        //EventSystem.current.SetSelectedGameObject(ControlsButton);
        navigationManager.firstSelected = ControlsButton;
        ControlsToolTip.SetActive(true);
        ShowTooltip(0);
    }

    public void OnSettings()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        //EventSystem.current.SetSelectedGameObject(ControlsButton);
        navigationManager.firstSelected = VolumeSlider;
        Settings.SetActive(true);
        
    }
    
    public void OnSettingsExit()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
     
        navigationManager.firstSelected = firstButton;
        Settings.SetActive(false);
    }

    

    public void OnControlsExit()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

        foreach (var t in tooltips)
        {
            if (t != null) t.SetActive(false);
        }

        //EventSystem.current.SetSelectedGameObject(firstButton);
        navigationManager.firstSelected = firstButton;
    }

    public void OnToolTipNext()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        int nextIndex = (currentTooltipIndex + 1) % tooltips.Length;
        ShowTooltip(nextIndex);
    }

    private void ShowTooltip(int index)
    {
        foreach (var t in tooltips)
        {
            if (t != null) t.SetActive(false);
        }

        if (tooltips[index] != null)
        {
            tooltips[index].SetActive(true);
        }

        currentTooltipIndex = index;

        switch (index)
        {
            case 0: navigationManager.firstSelected = ControlsButton; break;
            case 1: navigationManager.firstSelected = CrystalButton; break;
            case 2: navigationManager.firstSelected = RunesButton; break;
            case 3: navigationManager.firstSelected = PotionsButton; break;
        }
    }

    public void OnExitGame()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        Application.Quit();
    }

    
}