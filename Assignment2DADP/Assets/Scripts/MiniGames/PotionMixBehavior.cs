using UnityEngine;
using UnityEngine.EventSystems;

public class PotionMixBehaviour : MonoBehaviour
{
    public GameObject Button;
    public InputManager inputManager;
    public PotionBehaviour potionBehaviour;

    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(Button);
    }

    public void OnMinigameComplete()
    {
        
        potionBehaviour.currentState = PotionBehaviour.CauldronState.Bottling;
        inputManager.SwitchToGameplay();
    }
}
