using UnityEngine;
using Ink.Runtime;

// dialogue system 
// Title: How to create a Dialogue System in Unity | RPG Style | Unity + Ink
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=l8yI_97vjZs&t=1227s
public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("StartQuest", (string questId) => StartQuest(questId));
        story.BindExternalFunction("AdvanceQuest", (string questId) => AdvanceQuest(questId));
        story.BindExternalFunction("FinishQuest", (string questId) => FinishQuest(questId));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("StartQuest");
        story.UnbindExternalFunction("AdvanceQuest");
        story.UnbindExternalFunction("FinishQuest");
    }
    private void StartQuest(string questId)
    {
        GameEventsManager.instance.questEvents.StartQuest(questId);
    }

    private void AdvanceQuest(string questId)
    {
        GameEventsManager.instance.questEvents.AdvanceQuest(questId);
    }

    private void FinishQuest(string questId)
    {
        GameEventsManager.instance.questEvents.FinishQuest(questId);
    }
}
