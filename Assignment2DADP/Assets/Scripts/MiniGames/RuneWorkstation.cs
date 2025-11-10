using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class RuneWorkstation : MonoBehaviour, IInteractable
{
    public GameObject heldObject;
    public RuneBehaviour runeBehavior;
    public RuneInteractables playerRune;
    public TutorialPopups tutorialPopups;

    public ParticleSystem SuccessParticles;
    public ParticleSystem FailParticles;
    public GameObject Arrow;
    //public GameObject OrderUI;
   // public bool OrderUIACtive;

    int interactionCount;
    int sceneIndex;
    void Start()
    {
        interactionCount = 0;
        if (sceneIndex == 2)
        {
            Arrow.SetActive(true);
        }
        else Arrow.SetActive(false);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Interact()
    {
        Arrow.SetActive(false);
        
        //OrderUI.SetActive(false);

        Debug.Log("trying to interact");
        if (heldObject == null)
        {
            if (interactionCount == 0 && sceneIndex ==2)
            {
                Arrow.SetActive(false);
                tutorialPopups.RunePopup1();
                interactionCount++;
              
            }
            Debug.Log("held object is null");
            return;
        }
        else if (heldObject.GetComponentsInChildren<RuneInteractables>() != null)
        {
            RuneInteractables[] runeBase = heldObject.GetComponentsInChildren<RuneInteractables>();
            if (interactionCount == 0 && sceneIndex == 2)
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
            if (interactionCount == 0 && sceneIndex == 2)
            {
                Arrow.SetActive(false);
                tutorialPopups.RunePopup1();
                interactionCount++;
               
            }
            return;
        }

    }
}