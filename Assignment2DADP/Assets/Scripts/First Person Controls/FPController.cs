using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Title: First Person Controller Script
// Author: Hayes, A
// Date: 09/08/2025
// Avalability: DIGA2001A Lecture Slides
public class FPController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 2f;
    public float verticalLookLimit = 80f;

    [Header("Pickup Settings")]
    public float pickupRange = 5f;
    public Transform holdPoint;
    private PickUpController pickupController;

    [Header("UI Elements")]
    public TextMeshProUGUI pickupText;

    [Header("Audio")]
    //public WalkingAudio walkingSound;

    [Header("Interaction")]
    [SerializeField] private float interactRange = 3f;

    [Header("Dialogue")]
    //[SerializeField] private DialogueController dialogueController;
    //[SerializeField] private DialogueText dialogueText;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private float verticalRotation = 0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        pickupController = GetComponent<PickUpController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovement();
        HandleLook();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    
    public void OnPickup(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (pickupController == null) // if no object is held try pickup
            {
               Debug.LogWarning("No Pickup Controller Found");
                return;
            }
            
        if (!pickupController.IsHolding)
        {
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
            {
                if (hit.transform.CompareTag("canPickUp"))
                {
                    pickupController.TryPickUp(hit.transform.gameObject, holdPoint, gameObject);
                }
            }
        }
        else
        {
            pickupController.Drop();
        }
    }
    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            Debug.Log("Press started");

            int mask = ~LayerMask.GetMask("holdLayer");

            /*
            if (dialogueController && dialogueController.gameObject.activeInHierarchy)
            {
                dialogueController.DisplayNextParagraph(dialogueText);
                return;
            }
            */

            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            Debug.Log("Raycast fired");
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange, mask, QueryTriggerInteraction.Ignore))
            {
                // try and fill in the cauldron bar thing
                if (hit.collider.TryGetComponent<IFillable>(out var fillable))
                {
                    //cauldronFill = fillable;
                    //cauldronFill.OnFillStart();
                    //filling = true;
                    Debug.Log("Started filling");
                    return;
                }

                // normal interactable items
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact();
                }
            }
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            /*
            if (cauldronFill != null)
            {
                Debug.Log("Cancelling Fill");
                cauldronFill.OnFillStop();
                cauldronFill = null;
                filling = false;
            }
            */
        }
    }

    public void HandleMovement()
    {
        Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized; // normalize movement vector
       
        controller.Move(move * moveSpeed * Time.deltaTime);
        //Debug.Log(move);

        if (moveInput != Vector2.zero)
        {
           // Debug.Log("Moving");
            //audioManager.HandleFootsteps();

        }
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
