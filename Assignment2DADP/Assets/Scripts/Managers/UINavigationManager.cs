using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;

public class UINavigationManager : MonoBehaviour
{

    public EventSystem eventSystem;
    //public GameObject firstSelected;

    private PlayerInput playerInput;
    private InputAction navigateAction;
    private InputAction pointAction;

   



    void OnEnable()
    {
        StartCoroutine(InitializeAfterSwitch());
    }

    private IEnumerator InitializeAfterSwitch()
    {
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;


        if (!eventSystem)
            eventSystem = EventSystem.current;


        playerInput = FindAnyObjectByType<PlayerInput>();

        if (playerInput != null)
        {
            navigateAction = playerInput.currentActionMap.FindAction("Navigate", true);
            Debug.Log("found action in action map");
            pointAction = playerInput.currentActionMap.FindAction("Point", true);
        }


        if (navigateAction != null)
            navigateAction.performed += OnNavigate;

        if (pointAction != null)
            pointAction.performed += OnMouseMove;


        if (firstSelected != null)
            eventSystem.SetSelectedGameObject(firstSelected);

    }

        void OnDisable()
    {
        if (navigateAction != null)
            navigateAction.performed -= OnNavigate;

        if (pointAction != null)
            pointAction.performed -= OnMouseMove;
    }

    private void OnMouseMove(InputAction.CallbackContext ctx)
    {
        if (eventSystem != null)
            eventSystem.SetSelectedGameObject(null);
        //Debug.Log("Mouse Move Detected");
    }

    private void OnNavigate(InputAction.CallbackContext ctx)
    {
        if (eventSystem != null && eventSystem.currentSelectedGameObject == null && firstSelected != null)
            eventSystem.SetSelectedGameObject(firstSelected);
    }

    private GameObject _firstSelected;
    public GameObject firstSelected
    {
        get => _firstSelected;
        set
        {
            _firstSelected = value;
            SelectFirstButton(); 
        }
    }

    private void SelectFirstButton()
    {
        if (_firstSelected != null && eventSystem != null)
        {
            StartCoroutine(SelectNextFrame(_firstSelected));
        }
    }

    private IEnumerator SelectNextFrame(GameObject button)
    {
        yield return null; 
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(button);
    }
}
