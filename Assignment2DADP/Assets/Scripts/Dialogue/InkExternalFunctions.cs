using UnityEngine;
using Ink.Runtime;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using System;

// dialogue system 
// Title: How to create a Dialogue System in Unity | RPG Style | Unity + Ink
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=l8yI_97vjZs&t=1227s
public class InkExternalFunctions
{
    private PopupManager popupManager;
    private CatTeleport catTeleport;
    private CatTeleport2 catTeleport2;
    private CustomerSpawner customerSpawner;

    public void Bind(Story story)
    {
        story.BindExternalFunction("StartQuest", (string questId) => StartQuest(questId));
        story.BindExternalFunction("AdvanceQuest", (string questId) => AdvanceQuest(questId));
        story.BindExternalFunction("FinishQuest", (string questId) => FinishQuest(questId));

        // movement binds
        story.BindExternalFunction("LockMove", () => LockMove());
        story.BindExternalFunction("UnlockMove", () => UnlockMove());
        story.BindExternalFunction("LockLook", () => LockLook());
        story.BindExternalFunction("UnlockLook", () => UnlockLook());

        //popup
        story.BindExternalFunction("ShowPopup", (string type) => ShowPopup(type));
        story.BindExternalFunction("ClosePopup", (string type) => ClosePopup(type));

        //cat teleport
        story.BindExternalFunction("TeleportCat", (string target) => TeleportCat(target));
        story.BindExternalFunction("TeleportCat2", (string target) => TeleportCat2(target));

        //customer
        story.BindExternalFunction("StartDay", () => StartDay());
    }


    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("StartQuest");
        story.UnbindExternalFunction("AdvanceQuest");
        story.UnbindExternalFunction("FinishQuest");

        story.UnbindExternalFunction("LockMove");
        story.UnbindExternalFunction("UnlockMove");
        story.UnbindExternalFunction("LockLook");
        story.UnbindExternalFunction("UnlockLook");
        story.UnbindExternalFunction("ShowPopup");
        story.UnbindExternalFunction("ClosePopup");
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

    private void LockMove()
    {
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();
    }
    private void UnlockMove()
    {
        GameEventsManager.instance.playerEvents.EnablePlayerMovement();
    }

    private void LockLook()
    {
        GameEventsManager.instance.playerEvents.DisablePlayerLook();
    }

    private void UnlockLook()
    {
        GameEventsManager.instance.playerEvents.EnablePlayerLook();
    }
    private void ShowPopup(string type)
    {
        PopupManager.Instance.ShowPopup(type);
    }

    private void ClosePopup(string type)
    {
        PopupManager.Instance.ClosePopup(type);
    }

    private void TeleportCat(string target)
    {
        var tp = UnityEngine.Object.FindFirstObjectByType<CatTeleport>();
        if (tp != null)
        {
            switch (target)
            {
                case "Rune":
                    tp.SpawnCatRune();
                    break;
                case "Potion":
                    tp.SpawnCatPotion();
                    break;
                case "Crystal":
                    tp.SpawnCatCrystal();
                    break;
                case "Table":
                    tp.SpawnCatTable();
                    break;
                default:
                    Debug.LogWarning("[Ink] TeleportCat unknown target: " + target);
                    break;
            }
        }

    }

    private void TeleportCat2(string target)
    {
        var tp = UnityEngine.Object.FindFirstObjectByType<CatTeleport2>();
        if (tp != null)
        {
            switch (target)
            {
                case "Start":
                    tp.SpawnCatStart();
                    break;
                case "End":
                    tp.SpawnCatEnd();
                    break;
                default:
                    Debug.LogWarning("[Ink] TeleportCat2 unknown target: " + target);
                    break;

            }
        }
    }

    private void StartDay()
    {

        var cs = UnityEngine.Object.FindFirstObjectByType<CustomerSpawner>();
        if (cs != null)
        {

           cs.StartDay();
        }
    }
   
}
   
