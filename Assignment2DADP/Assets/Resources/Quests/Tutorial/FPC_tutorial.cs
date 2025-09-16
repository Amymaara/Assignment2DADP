using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPC_tutorial : QuestSteps
{

    [Header("Inputs")]
    public PlayerInput playerInput;
    public string Movement = "Movement";
    public string Look = "Look";
    public string Interact = "Interact";

    [Header("Game References")]
    public Transform player;
    public Camera mainCamera;
    public Transform interactTarget;

    [Header("Requirements")]
    public float moveRequired = 3f;
    public float lookRequired = 180f;

    [Header("UI")]
    public TextMeshProUGUI toolTip;

    // input actions we will be using 
    InputAction movementAction;
    InputAction lookAction;
    InputAction interactAction;

    //
    bool interactPressed;

    private void Start()
    {
        // finds actions in action map by name
        movementAction = playerInput.actions.FindAction(Movement, throwIfNotFound: true);
        lookAction = playerInput.actions.FindAction(Look, throwIfNotFound: true);
        interactAction = playerInput.actions.FindAction(Interact, throwIfNotFound: true);

        
        movementAction.Enable();
        lookAction.Enable();
        interactAction.Enable();

        StartCoroutine(fpcTutorial());
    }

    IEnumerator fpcTutorial()
    {
        // step 1

        movementAction.Enable();
        lookAction.Disable();
        interactAction.Disable();  

        Vector3 startPos = player.position;
        yield return new WaitUntil(() => Vector3.Distance(player.position, startPos) >= moveRequired);
        Debug.Log("Movement done");

        FinishQuestStep();
    }
}
