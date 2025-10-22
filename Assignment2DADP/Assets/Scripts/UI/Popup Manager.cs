using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [Header("popups")]
    public GameObject tarotPanel;
    public GameObject movementPanel;
    public GameObject lookPanel;

    private void Awake()
    {
        Instance = this;
      
        if (tarotPanel) tarotPanel.SetActive(false);
        if (movementPanel) movementPanel.SetActive(false);
        if (lookPanel) lookPanel.SetActive(false);
    }
    
    public void ShowPopup(string type)
    {
        switch (type.ToLowerInvariant())
        {
            case "tarot":
                tarotPanel.SetActive(true);
                break;

            case "movement":
                movementPanel.SetActive(true);
                break;

            case "look":
                lookPanel.SetActive(true);
                break;


        }

    }

    public void ClosePopup(string type)
    {
        switch(type.ToLowerInvariant())
        {
            case "tarot":
                tarotPanel.SetActive(false);
                break;

            case "movement":
                movementPanel.SetActive(false);
                break;

            case "look":
                lookPanel.SetActive(false);
                break;


            }
        }
}
