using Unity.VisualScripting;
using UnityEngine;

public class RuneWorkstation : MonoBehaviour, IInteractable
{
    public GameObject heldObject;
    public RuneBehaviour runeBehavior;
    public RuneInteractables playerRune;
    public TutorialPopups tutorialPopups;

    public ParticleSystem SuccessParticles;
    public ParticleSystem FailParticles;

    int interactionCount;
    void Start()
    {
        interactionCount = 0;
    }

    public void Interact()
    {
        

        Debug.Log("trying to interact");
        if (heldObject == null)
        {
            if (interactionCount == 0)
            {
                tutorialPopups.RunePopup1();
                interactionCount++;
            }
            Debug.Log("held object is null");
            return;
        }
        else if (heldObject.GetComponentsInChildren<RuneInteractables>() != null)
        {
            RuneInteractables[] runeBase = heldObject.GetComponentsInChildren<RuneInteractables>();
            if (interactionCount == 0)
            {
                tutorialPopups.RunePopup1();
                interactionCount++;
            }
            else
            {
                foreach (RuneInteractables rune in runeBase)
                {
                    if (rune.finishedProduct == false)
                    {
                        playerRune = rune;
                        runeBehavior.OnRuneTableInteract(playerRune);
                        Debug.Log("Interacting with Ruin Table");
                    }

                }

            }
        }
        else
        {
            if (interactionCount == 0)
            {
                tutorialPopups.RunePopup1();
                interactionCount++;
            }
            return;
        }

    }
}