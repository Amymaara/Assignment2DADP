using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;

//I did use chatGPT to help with this script. I did most of the initial stuff by myself but the code kept breaking when
//there was another canvas active in the heirachy. That would just break the click function for whatever reason.
//I got consult help but they couldnt figure it out either. 
//Title: UI navigation issues
//Author: ChatGPT 
//Date accessed: 23 October 2025
//Code version: 1
//Availability: https://chatgpt.com/c/68f9e9ef-c978-832d-a1c5-e987d8c676b8

public class UINavigationManager : MonoBehaviour
{
    public EventSystem eventSystem;

    private PlayerInput playerInput;
    private InputAction navigateAction;
    private InputAction pointAction;
    private InputActionMap lastMap;
    private PointerEventData pointerData;
    private GameObject currentDragTarget;

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

    

    private void OnEnable()
    {
        StartCoroutine(InitializeAfterSwitch());
    }

    private IEnumerator InitializeAfterSwitch()
    {
        // Wait a few frames to allow PlayerInput and UI to initialize
        yield return new WaitForSecondsRealtime(0.2f);

        if (!eventSystem)
            eventSystem = EventSystem.current;

        if (playerInput == null)
            playerInput = FindAnyObjectByType<PlayerInput>();

        if (playerInput == null)
        {
            Debug.LogWarning("No PlayerInput found in scene.");
            yield break;
        }

        // subscribe to current map
        SubscribeToMap(playerInput.currentActionMap);

        if (firstSelected != null)
            eventSystem.SetSelectedGameObject(firstSelected);
    }

    private void OnDisable()
    {
        UnsubscribeCurrentMap();
    }

   

    void Update()
    {
        if (playerInput == null) return;

       
        if (playerInput.currentActionMap != lastMap)
        {
            SubscribeToMap(playerInput.currentActionMap);
        }

       
        if (pointerData == null)
            pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Mouse.current.position.ReadValue();

        
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

      
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (results.Count > 0)
            {
                var go = results[0].gameObject;
                currentDragTarget = go;

                
                ExecuteEvents.ExecuteHierarchy(go, pointerData, ExecuteEvents.pointerDownHandler);
            }
        }

        if (Mouse.current.leftButton.isPressed && currentDragTarget != null)
        {
            ExecuteEvents.ExecuteHierarchy(currentDragTarget, pointerData, ExecuteEvents.dragHandler);
        }

       
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (currentDragTarget != null)
            {
                ExecuteEvents.ExecuteHierarchy(currentDragTarget, pointerData, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.ExecuteHierarchy(currentDragTarget, pointerData, ExecuteEvents.pointerClickHandler);
                currentDragTarget = null;
            }
        }
    }

    private void SubscribeToMap(InputActionMap map)
    {
        if (map == null) return;

        // Unsubscribe old
        UnsubscribeCurrentMap();

        lastMap = map;

        navigateAction = map.FindAction("Navigate", false);
        pointAction = map.FindAction("Point", false);

        if (navigateAction != null)
            navigateAction.performed += OnNavigate;

        if (pointAction != null)
            pointAction.performed += OnMouseMove;

        map.Enable();
        Debug.Log($"Subscribed to action map: {map.name}");
    }

    private void UnsubscribeCurrentMap()
    {
        if (lastMap == null) return;

        var oldNavigate = lastMap.FindAction("Navigate", false);
        var oldPoint = lastMap.FindAction("Point", false);

        if (oldNavigate != null)
            oldNavigate.performed -= OnNavigate;

        if (oldPoint != null)
            oldPoint.performed -= OnMouseMove;

        lastMap = null;
    }

    private void OnMouseMove(InputAction.CallbackContext ctx)
    {
        if (eventSystem != null)
            eventSystem.SetSelectedGameObject(null);
    }

    private void OnNavigate(InputAction.CallbackContext ctx)
    {
        if (eventSystem != null && eventSystem.currentSelectedGameObject == null && firstSelected != null)
            eventSystem.SetSelectedGameObject(firstSelected);
    }
   

    private void SelectFirstButton()
    {
        if (_firstSelected != null && eventSystem != null)
            StartCoroutine(SelectNextFrame(_firstSelected));
    }

    
    private IEnumerator SelectNextFrame(GameObject button)
    {
        yield return null;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(button);
    }
    
}
