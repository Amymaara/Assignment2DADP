using System;
using UnityEngine;

// dialogue system 
// Title: How to create a Dialogue System in Unity | RPG Style | Unity + Ink
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=l8yI_97vjZs&t=1227s
public class PlayerEvents
{
    // movement 
    public event Action onDisablePlayerMovement;
    public event Action onEnablePlayerMovement;

    public void DisablePlayerMovement()
    {
        if (onDisablePlayerMovement != null)
        {
            onDisablePlayerMovement();
        }
    }
    
    public void EnablePlayerMovement()
    {
        if (onEnablePlayerMovement != null)
        {
            onEnablePlayerMovement();
        }
    }

    // look/camera

    public event Action onDisablePlayerLook;
    public event Action onEnablePlayerLook;

    public void DisablePlayerLook()
    {
        if (onDisablePlayerLook != null)
        {
            onDisablePlayerLook();
        }
    }

    public void EnablePlayerLook()
    {
        if (onEnablePlayerLook != null)
        {
            onEnablePlayerLook();
        }
    }
}
