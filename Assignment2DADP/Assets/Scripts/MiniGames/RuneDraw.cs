using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.XR;


public class RuneDraw : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject cursor;
    public Camera cameraMain;
    public Transform runeCenter;
    public LineRenderer targetLine;
    public GameObject targetLineGameObject;
    public LineRenderer playerLine;
    public GameObject playerLineGameObject;
    public GameObject stampset;
    public InputManager inputManager;
    public RuneWorkstation workstation;
    //public RuneBehaviour runeBehaviour;
    //public Belladona cat;
    public GameObject firstButton;
    public UINavigationManager navigationManager;

    //public GameObject UIOrder;
    //public bool UIOrderActive;
    public InputSystemUIInputModule uiInputModule;



    [Header("Settings")]
    public float controllerSpeed = 0.08f;   // units per second for controller
    public float mouseSpeed = 0.08f;
    public float baseSensitivity = 0.08f;
    public float controllerMultiplier = 4f;
    public float pointSpacing = 0.05f;
    public float accuracyThreshold = 0.2f;
    public float deadzone = 0.05f;
    public float maxMovePerFrame = 0.5f;
    [SerializeField]
    private float fixedWorldY;
    private Vector3 previousCursorPosition;
    private Vector2 cursorMove;
    private bool isDrawing;
    public float smoothSpeed = 5f;
    private Vector3 smoothedMove;
    public float runeRadius = 5f;
    public bool canDraw;





    private void OnEnable()
    {
        controllerSpeed = 25f;
        mouseSpeed = 0.05f;

        EventSystem.current?.SetSelectedGameObject(null);

        inputManager.SwitchToRuneMenu();
        previousCursorPosition = transform.position;
        playerLine.positionCount = 0;
        fixedWorldY = runeCenter.position.y;
        Cursor.visible = false;

        //if (UIOrder.activeInHierarchy) 
        //{ 
        //    UIOrderActive = true;
        //}
        //else { UIOrderActive = false; }

        //UIOrder.SetActive(false);
        if (uiInputModule != null)
            uiInputModule.enabled = false;
    }

    

    public void ChooseTargetPath(int index)
    {
        targetLine = stampset.transform.GetChild(index).GetComponent<LineRenderer>();
        targetLineGameObject = targetLine.gameObject;
        targetLineGameObject.SetActive(true);

    }

    private void Update()
    {


        HandlePoint();



        if (isDrawing)
        {
            DrawingStart();

        }

       
            if (Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame)
                Debug.Log("A pressed in RuneDraw!");

           
       
    }



    public void OnDrawPath(InputAction.CallbackContext context)
    {
        cursorMove = context.ReadValue<Vector2>();
    }

    // adapted from pix and dev, i had to try find a way to get it to work with the new input system & 3D.  
    //Title: How to Draw in Unity using Line Renderer | Unity Tutorial
    //Author: Pix and Dev
    //Date Created: 18 Mar 2023
    //Date accessed: 14 August 2025
    //Code version: 1
    //Availability: https://www.youtube.com/watch?v=M4247oZ8sEI

    //I did use chatGPT to help with the smoothing of the movement.
    //Title: Line Tracing Minigame Help
    //Author: ChatGPT 
    //Date accessed: 14 August 2025
    //Code version: 1
    //Availability: https://chatgpt.com/c/689cde06-8b18-832c-bd0d-f75bdde15edd
    public void HandlePoint()
    {
        Vector3 move = Vector3.zero;

        // Detect if input is coming from mouse or controller
        bool usingMouse = Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero;
        bool usingController = Gamepad.current != null && !usingMouse;

        // Apply deadzone for controller
        Vector2 filteredInput = cursorMove;
        if (usingController && filteredInput.magnitude < deadzone)
            filteredInput = Vector2.zero;

        if (usingMouse)
        {
            // Mouse uses delta directly (pixel-based)
            Vector2 delta = Mouse.current.delta.ReadValue();
            move = new Vector3(delta.x, 0f, delta.y) * mouseSpeed * 0.01f; // scaled down
        }
        else if (usingController)
        {
            // Controller uses stick input (normalized)
            move = new Vector3(filteredInput.x, 0f, filteredInput.y) * controllerSpeed * Time.deltaTime ;
        }

        // Smooth + clamp
        smoothedMove = Vector3.Lerp(smoothedMove, move, Time.deltaTime * smoothSpeed);
        smoothedMove = Vector3.ClampMagnitude(smoothedMove, maxMovePerFrame);

        cursor.transform.position += smoothedMove;

        // Constrain within rune circle
        Vector3 direction = cursor.transform.position - runeCenter.position;
        float distance = direction.magnitude;

        if (distance > runeRadius)
            cursor.transform.position = runeCenter.position + direction.normalized * runeRadius;

        // Lock Y
        Vector3 pos = cursor.transform.position;
        pos.y = fixedWorldY;
        cursor.transform.position = pos;
    }



    public void OnDrawRune(InputAction.CallbackContext context)
    {
        Debug.Log("trying to draw");

        if (!canDraw)
        {
            //EventSystem.current.SetSelectedGameObject(firstButton);
            navigationManager.firstSelected = firstButton;
            return;
        }
        if (context.started)
        {
            HandlePoint();
            previousCursorPosition = cursor.transform.transform.position;
            isDrawing = true;
            DrawingStart();
        }
        if (context.canceled)
        {
            DrawingStop();
        }
    }
    int currentcount = 10;
    
    public void DrawingStart()
    {
        Vector3 currentCursorPosition = cursor.transform.transform.position;
        if (Vector3.Distance(previousCursorPosition, cursor.transform.position) > pointSpacing)
        {
            playerLine.positionCount++;
            playerLine.SetPosition(playerLine.positionCount - 1, currentCursorPosition);
            previousCursorPosition = currentCursorPosition;
            if (currentcount < 10)
            {
                currentcount++;
            }
            else
            {
                AudioManager.PlaySound(AudioManager.SoundType.RUNEDRAW, 0.001f);
                currentcount = 0;
            }
               

        }
    }

    public void DrawingStop()
    {

        isDrawing = false;
        float playerAccuracy = CalculateAccuracy(targetLine, playerLine, pointSpacing, accuracyThreshold);
        Debug.Log(playerAccuracy);
        workstation.playerRune.skillAcurracy = playerAccuracy;
        workstation.runeBehavior.Outcome(playerAccuracy);
        playerLine.positionCount = 0;
        cursor.SetActive(false);
        targetLineGameObject.SetActive(false);
        workstation.playerRune.finishedProduct = true;
        if (uiInputModule != null)
            uiInputModule.enabled = true;
        inputManager.SwitchToGameplay();
        playerLineGameObject.SetActive(false); // the object this script is on
        //inputManager.SwitchToGameplay();

        //UIOrder.SetActive(UIOrderActive);
    }

    

    

    /*
    public void Outcome()
    {
        if (workstation.playerRune.material != RuneInteractables.RuneMaterial.Stone ||
            workstation.playerRune.stamp != RuneInteractables.Stamp.Star)
        {
            cat.SetOutcome(RuneOutcome.WrongMaterials);
        }
        else if (workstation.playerRune.skillAcurracy < 0.60f)
        {
            cat.SetOutcome(RuneOutcome.LowAccuracy);
        }
        else
        {
            cat.SetOutcome(RuneOutcome.Success);
        }
    }
    */

    // based on this comment
    //Title: Mario Crazy Cutter Replica Help
    //Author: Mysterion336
    //Date: 18 August 2025
    //Code version: 1
    //Availability: https://discussions.unity.com/t/mario-crazy-cutter-replica-help/1678265

    List<Vector3> GetDensifiedPath(LineRenderer line, float spacing)
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < line.positionCount - 1; i++)
        {
            Vector3 start = line.GetPosition(i);
            Vector3 end = line.GetPosition(i + 1);
            float dist = Vector3.Distance(start, end);

            int steps = Mathf.CeilToInt(dist / spacing);

            for (int s = 0; s <= steps; s++)
            {
                float t = (float)s / steps;
                points.Add(Vector3.Lerp(start, end, t));
            }
        }
        return points;
    }

    // based on this comment, i made some edits
    //Title: Mario Crazy Cutter Replica Help
    //Author: Mysterion336
    //Date: 18 August 2025
    //Code version: 1
    //Availability: https://discussions.unity.com/t/mario-crazy-cutter-replica-help/1678265

    public float CalculateAccuracy(LineRenderer target, LineRenderer player, float spacing, float threshold)
    {
        List<Vector3> denseTarget = GetDensifiedPath(target, spacing);
        int coveredPoints = 0;

        for (int i = 0; i < denseTarget.Count; i++)
        {
            // Convert target point from local to world space
            Vector3 targetPointWorld = target.transform.TransformPoint(denseTarget[i]);
            targetPointWorld.y = fixedWorldY;

            bool covered = false;
            for (int j = 0; j < player.positionCount; j++)
            {
                Vector3 playerPoint = player.GetPosition(j);
                playerPoint.y = fixedWorldY;

                if (Vector3.Distance(targetPointWorld, playerPoint) <= threshold)
                {
                    covered = true;
                    break;
                }
            }

            if (covered) coveredPoints++;
        }

        return (float)coveredPoints / denseTarget.Count;
    }

}

