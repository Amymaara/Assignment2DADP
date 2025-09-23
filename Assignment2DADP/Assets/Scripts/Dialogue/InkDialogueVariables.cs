using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;

// dialogue system 
// Title: How to create a Dialogue System in Unity | RPG Style | Unity + Ink
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=l8yI_97vjZs&t=1227s

public class InkDialogueVariables 
{
    private Dictionary<string, Ink.Runtime.Object> variables;

    public InkDialogueVariables(Story story)
    {
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in story.variablesState)
        {
            Ink.Runtime.Object value = story.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialised global dialogue vairable:" + name + "=" + value);
        }
    }

    public void SyncVariablesAndStartListening(Story story)
    {
        SyncVariablesToStory(story);
        story.variablesState.variableChangedEvent += UpdateVaraibleState;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= UpdateVaraibleState;
    }

    public void UpdateVaraibleState(string name, Ink.Runtime.Object value)
    {
        if (!variables.ContainsKey(name))
        {
            return;
        }
        variables[name] = value;
        Debug.Log("Updated dialogue variable: " + name + " = " + value);
    }

    private void SyncVariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
