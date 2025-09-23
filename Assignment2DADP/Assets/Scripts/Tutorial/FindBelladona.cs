using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.Rendering;
using UnityEditorInternal;
using UnityEngine.InputSystem;

public class FindBelladona : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private InputActionReference advanceDialogue;
    //[SerializeField] private CandleManager candleManager;

    private Story story;
    private bool hasStarted;

    private void Awake()
    {
        contentParent.SetActive(false);
    }

    private void OnEnable()
    {
        advanceDialogue.action.Enable();
    }

    private void OnDisable()
    {
        advanceDialogue.action.Disable();
    }

    private void Update()
    {
        if (!hasStarted || story == null)
        {
            return;
        }

        if (advanceDialogue != null && advanceDialogue.action.WasPressedThisFrame())
        {
            ContinueStory();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasStarted) return;
        
        if (other.CompareTag("Player"))
        {
            hasStarted = true;
            
            contentParent.SetActive(true);
            story = new Story(inkJson.text);


            ContinueStory();
        }

        else
        {
            ExitDialogueMode();
        }

    }


    private void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }

        else
        {
            ExitDialogueMode();
        }

    }

    private void ExitDialogueMode()
    {
        hasStarted = false;
        contentParent.SetActive(false);
        story = null;
        if (dialogueText) dialogueText.text = "";
        this.gameObject.SetActive(false);

       
      /*  if (candleManager == null)
        {
            var mgrRoot = GameObject.Find("Managers");
            if (mgrRoot != null)
                candleManager = mgrRoot.GetComponentInChildren<CandleManager>(true);
        }

        candleManager.TurnOnCatCandles();
      */
    }



}
