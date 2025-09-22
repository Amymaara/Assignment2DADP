using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static AudioManager;

public class PauseMenu : MonoBehaviour
{
    public InputManager inputManager;
    public GameObject SettingsPopup;
    public GameObject firstButton;
    public GameObject SettingsButton;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
        SettingsPopup.SetActive(false);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
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
        EventSystem.current.SetSelectedGameObject(SettingsButton);
        SettingsPopup.SetActive(true);
    }

    public void OnSettingsExit()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
        SettingsPopup.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstButton);

    }

    public void OnExitGame()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 1);
        Application.Quit();
    }

    
}
