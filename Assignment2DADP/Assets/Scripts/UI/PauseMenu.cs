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

    [Header("Tooltips")]
    public GameObject ControlsToolTip;
    public GameObject RunesToolTip;
    public GameObject PotionsToolTip;

    private GameObject[] tooltips;
    private int currentTooltipIndex = 0;

    private void Awake()
    {
        tooltips = new GameObject[] { ControlsToolTip, RunesToolTip, PotionsToolTip };
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
        ControlsToolTip.SetActive(false);
        RunesToolTip.SetActive(false);
        PotionsToolTip.SetActive(false);

    }

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

    public void OnResume()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
        inputManager.SwitchToGameplay();
    }

    public void OnSettings()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
        EventSystem.current.SetSelectedGameObject(ControlsButton);
        ControlsToolTip.SetActive(true);
        ShowTooltip(0);
    }

    public void OnSettingsExit()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);

        foreach (var t in tooltips)
        {
            if (t != null) t.SetActive(false);
        }

        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void OnToolTipNext()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
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
            case 0: EventSystem.current.SetSelectedGameObject(ControlsButton); break;
            case 1: EventSystem.current.SetSelectedGameObject(RunesButton); break;
            case 2: EventSystem.current.SetSelectedGameObject(PotionsButton); break;
        }
    }

    public void OnExitGame()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
        Application.Quit();
    }
}