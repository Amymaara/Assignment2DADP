using UnityEngine;
using System;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour 
{
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;
    private Story story;
    private int currentChoiceIndex = -1;
   
    private bool dialoguePlaying = false;
    private InkExternalFunctions inkExternalFunctions;
    private InkDialogueVariables inkDialogueVariables;

    private void Awake()
    {
        story = new Story(inkJson.text);
        inkExternalFunctions = new InkExternalFunctions();
        inkExternalFunctions.Bind(story);
        inkDialogueVariables = new InkDialogueVariables(story);
    }

    private void OnDestroy()
    {
        inkExternalFunctions.Unbind(story); 
    }
    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameEventsManager.instance.inputEvents.onInteractPressed += InteractPressed;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable += UpdateInkDialogueVariable;
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameEventsManager.instance.inputEvents.onInteractPressed -= InteractPressed;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable -= UpdateInkDialogueVariable;
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        GameEventsManager.instance.dialogueEvents.UpdateInkDialogueVariable(quest.info.id + "State",
           new StringValue(quest.state.ToString())
            );

    }

    private void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        inkDialogueVariables.UpdateVaraibleState(name, value);
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void InteractPressed(InputEventsContext inputEventsContext)
    {
        if (!inputEventsContext.Equals(InputEventsContext.DIALOGUE))
        {
            return;
        }

        ContinueOrExitStory();
    }

    private void EnterDialogue(string knotName)
    {
       if (dialoguePlaying)
        {
            return;
        }

        dialoguePlaying = true;

        GameEventsManager.instance.dialogueEvents.DialogueStarted();

        GameEventsManager.instance.playerEvents.DisablePlayerMovement();

        GameEventsManager.instance.inputEvents.ChangeInputEventsContext(InputEventsContext.DIALOGUE);

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.Log("Knot name ws the empty string when entering dialogue");
        }

        inkDialogueVariables.SyncVariablesAndStartListening(story);

        ContinueOrExitStory();

    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);

            currentChoiceIndex = -1;
        }
        
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            while (IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            if (IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }

            else
            {
                GameEventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
            }

        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    { 

        dialoguePlaying = false;

        GameEventsManager.instance.dialogueEvents.DialogueFinished();

        GameEventsManager.instance.playerEvents.EnablePlayerMovement();

        GameEventsManager.instance.inputEvents.ChangeInputEventsContext(InputEventsContext.DEFAULT);

        inkDialogueVariables.StopListening(story);
        
        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
}
