using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
    public void OnResume()
    {
        inputManager.SwitchToGameplay();
    }

    public void OnSettings()
    {
        EventSystem.current.SetSelectedGameObject(SettingsButton);
        SettingsPopup.SetActive(true);
    }

    public void OnSettingsExit()
    {
        SettingsPopup.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstButton);

    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
