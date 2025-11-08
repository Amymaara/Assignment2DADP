using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

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
    private bool canMove = true;
    private Animator animator;

    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 2f;         
    [Range(0.01f, 2f)] public float controllerSpeed = 120f; 
    public float verticalLookLimit = 80f;
    private bool canLook = true;

    [Header("Pickup Settings")]
    public float pickupRange = 5f;
    public PickUpObject heldObject;
    public Transform holdPoint;
    public IngredientObject holdObject;
    public ParticleSystem PickupParticles;


    [Header("UI Elements")]
    public TextMeshProUGUI pickupText;
    public InputManager inputManager;

    [Header("Audio")]
    //public WalkingAudio walkingSound;

    [Header("Minigame Settings")]
    public bool filling = false;
    private IFillable cauldronFill;
    public PotionBehaviour potionBehaviour;

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



    [SerializeField] private float footstepInterval = 0.3f;
    private float footstepTimer = 0f;

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onEnablePlayerLook += EnableLook;
        GameEventsManager.instance.playerEvents.onDisablePlayerLook += DisableLook;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement += DisableMove;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement += EnableMove;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onEnablePlayerLook -= EnableLook;
        GameEventsManager.instance.playerEvents.onDisablePlayerLook -= DisableLook;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement -= DisableMove;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement -= EnableMove;
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (cauldronFill != null && filling)
        {
            cauldronFill.Fill();




        }

        HandleMovement();
        HandleLook();

        if (moveInput.magnitude > 0)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                AudioManager.PlaySound(AudioManager.SoundType.FOOTSTEP, 0.09f);
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }

    }

    public void LookSensitivity(float x)
    {
        lookSensitivity = x;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        inputManager.SwitchToUI();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != null)
        {
            //AudioManager.PlaySound(AudioManager.SoundType.FOOTSTEP);
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (heldObject == null)
        {
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
            {
                PickUpObject pickUp = hit.collider.GetComponent<PickUpObject>();
                if (pickUp != null)
                {
                    ForcePickUp(pickUp.gameObject);
                }
            }
        }
        else
        {
            ForceDrop();
        }


        /*
       // This is the old pickup/pickupcontroller stuff
        

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

        */

    }

    public void ForcePickUp(GameObject obj)
    {
        ForceDrop();


        PickUpObject pickUp = obj.GetComponent<PickUpObject>();
        if (pickUp != null)
        {
            AudioManager.PlaySound(SoundType.PICKUP, 0.05f);
            pickUp.PickUp(holdPoint, gameObject);
            heldObject = pickUp;

            IngredientObject intObj = obj.GetComponent<IngredientObject>();
            if (intObj != null)
                holdObject = intObj;
        }

        if (PickupParticles != null)
        {
            PickupParticles.Play();
        }
    }

    public void ForceDrop()
    {
        if (heldObject != null)
        {
            if (PickupParticles != null)
            {
                PickupParticles.Stop();
            }

            heldObject.Drop();
            heldObject = null;
            holdObject = null;
        }
    }

    public void SpawnFullBottleInHand(GameObject bottlePrefab)
    {
        if (bottlePrefab == null)
        {
            Debug.LogWarning("No bottle prefab");
            return;
        }

        ForceDrop();

        GameObject bottleInstance = Instantiate(bottlePrefab, holdPoint.position, holdPoint.rotation);
        ForcePickUp(bottleInstance);
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {

        if (ctx.phase == InputActionPhase.Started)
        {


            /*
            if (dialogueController && dialogueController.gameObject.activeInHierarchy)
            {
                dialogueController.DisplayNextParagraph(dialogueText);
                return;
            }
            */

            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Debug.Log("I hit " + hit.collider.name);
                /* var catcustomer = hit.collider.GetComponentInChildren<PotionCatInteract>();
                 if (catcustomer)
                 {
                     var held = holdPoint.GetComponentInChildren<ServeableItem>();
                     if (held)
                     {
                         bool ok = catcustomer.TryServe(held);
                         if (ok) Destroy(held.gameObject);
                     }
                 }
                */

                var catcustomer = hit.collider.GetComponentInParent<PotionCatInteract>();
                if (catcustomer == null)
                {
                    Debug.Log("No PotionCatInteract found on what I hit");
                }
                else
                {
                    var held = holdPoint.GetComponentInChildren<ServeableItem>();
                    if (held == null)
                    {
                        Debug.Log("Player is not holding a ServeableItem under holdPoint");
                    }
                    else
                    {
                        Debug.Log("About to call TryServe on cat with " + held.name);
                        bool ok = catcustomer.TryServe(held);
                        if (ok) Destroy(held.gameObject);
                    }
                }
            
                var catrunecustomer = hit.collider.GetComponentInParent<RuneCatInteract>();
                if (catrunecustomer)
                {
                    var held = holdPoint.GetComponentInChildren<ServeableItem>();
                    if (held)
                    {
                        bool ok = catrunecustomer.TryServe(held);
                        if (ok) Destroy(held.gameObject);
                    }
                }

                var catcrystalcustomer = hit.collider.GetComponentInParent<CrystalCatInteract>();
                if (catcrystalcustomer)
                {
                    var held = holdPoint.GetComponentInChildren<ServeableItem>();
                    if (held)
                    {
                        bool ok = catcrystalcustomer.TryServe(held);
                        if (ok) Destroy(held.gameObject);
                    }
                }

                var customer = hit.collider.GetComponentInChildren<Customer>();
                if (customer)
                {
                    var held = holdPoint.GetComponentInChildren<ServeableItem>();
                    if (held)
                    {
                        bool ok = customer.TryServe(held);
                        if (ok) Destroy(held.gameObject);
                    }
                }



                // try and fill in the cauldron bar thing
                if (hit.collider.TryGetComponent<IFillable>(out var fillable) && potionBehaviour.currentState == PotionBehaviour.CauldronState.Filling)
                {
                    cauldronFill = fillable;
                    cauldronFill.OnFillStart();
                    filling = true;
                    Debug.Log("Started filling");
                    return;
                }

                // normal interactable items
                else if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact();
                }
            }

            else
            {
                Debug.Log("Raycast didn't hit anything interactable");
            }
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            if (cauldronFill != null)
            {
                Debug.Log("Cancelling Fill");
                cauldronFill.OnFillStop();
                cauldronFill = null;
                filling = false;
            }
        }

        if (ctx.performed)
        {

            var mgr = GameEventsManager.instance;
            if (mgr?.inputEvents != null)
            {
                mgr.inputEvents.InteractPressed();
            }
        }
    }

    public void HandleMovement()
    {
        /* Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized; // normalize movement vector

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
        */

        Vector3 move = Vector3.zero; // starts the player at zero / origin
        if (canMove)
        {
            move = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;

            controller.Move(move * moveSpeed * Time.deltaTime);
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

            Vector3 horizontalMove = new Vector3(moveInput.x, 0, moveInput.y).normalized * moveSpeed;
            float currentSpeed = horizontalMove.magnitude; 
            animator.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime);
            animator.SetBool("Holding", heldObject != null);

            
        }
    }
    private void HandleLook()
    {
        if (!canLook) return;

        float mouseX = 0f;
        float mouseY = 0f;

        bool usingMouse = Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero;
        bool usingController = Gamepad.current != null && Gamepad.current.rightStick.ReadValue() != Vector2.zero;

        if (usingMouse)
        {
            // Mouse delta per frame, multiply by sensitivity
            mouseX = lookInput.x * lookSensitivity;
            mouseY = lookInput.y * lookSensitivity;
        }
        else if (usingController)
        {
            // Controller stick is -1..1, multiply by desired degrees per second and deltaTime
            Vector2 stick = lookInput;
            mouseX = stick.x * controllerSpeed * Time.deltaTime;
            mouseY = stick.y * controllerSpeed * Time.deltaTime;
        }
        else return;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void EnableMove()
    {
        canMove = true;
    }

    private void DisableMove()
    {
        canMove = false;
    }

    private void EnableLook()
    {
        canLook = true;
    }

    private void DisableLook()
    {
        canLook = false;
    }
}
