using UnityEngine;
using System;
using System.Diagnostics;

public class GameEventsManager : MonoBehaviour
{
    
    public static GameEventsManager instance {  get; private set; }

    public QuestEvents questEvents;

    public DialogueEvents dialogueEvents;

    private void Awake()
    {
        if (instance != null)
        {
            UnityEngine.Debug.LogError("More than one GameEventsManager found in scene");
        }
        instance = this;

        //initialise all events

        questEvents = new QuestEvents();
        dialogueEvents = new DialogueEvents();
    }

}
