using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PotionMixBehaviour : MonoBehaviour
{
    
    public InputManager inputManager;
    public PotionBehaviour potionBehaviour;
    public GameObject[] ArrowPrefabs;
    public List<GameObject> RandomArrows = new List<GameObject>();
    public GameObject LayoutGroup;
    int currentIndex;
    public MixButtons currentButton;
    public bool MinigameSuccess;
    public Slider TimerSlider;
    private bool GameEnded;

    public void OnEnable()
    {
        MiniGameSetUp();
        GameEnded = false;
    }

    private void OnDisable()
    {
        foreach (Transform arrow in LayoutGroup.transform)
        {
            Destroy(arrow.gameObject);
        }
    }

    public void Update()
    {
        if (TimerSlider.value <= 0.01 && GameEnded == false) //for some reason the timer doesnt go to 0???
        {
            MinigameSuccess = false;
            Debug.Log("Mini Game Fail");
            GameEnded = true;
            StartMiniGameEndDelay();

        }
    }

    // random object spawning help from this video
    // https://www.youtube.com/watch?v=bIM3VAiZHeQ
    public void MiniGameSetUp()
    {
        for (int i = 0; i < 6; i++)
        {
            int randomIndex = Random.Range(0, ArrowPrefabs.Length);
            Instantiate(ArrowPrefabs[randomIndex], LayoutGroup.transform);
        }

        currentIndex = 0;

        RandomArrows.Clear();

        foreach (Transform arrow in LayoutGroup.transform)
        {
            RandomArrows.Add(arrow.gameObject);
        }

        GameObject temp = RandomArrows[currentIndex];
        currentButton = temp.GetComponent<MixButtons>();
    }

    public void NextArrow()
    {
        if (currentIndex <= ArrowPrefabs.Length)
        {
            currentIndex++;
            GameObject temp = RandomArrows[currentIndex];
            currentButton = temp.GetComponent<MixButtons>();
        }
        else
        {

            MinigameSuccess = true;
            Debug.Log("Mini Game Pass");
            Debug.Log("Finished");
            StartMiniGameEndDelay();
        }
    }

    public void EditArrow()
    {
        GameObject temp = RandomArrows[currentIndex];
        Image img = temp.GetComponent<Image>();
        img.color = Color.grey;
    }

    public void OnMinigameComplete()
    {
        // send the success or fail bool to wherever it needs to go like particle effect player?, maybe sound and stuff should only play after player leaves minigame?

        if (!MinigameSuccess)
        {
            potionBehaviour.recipe = PotionBehaviour.Recipe.None;
            // play fail particles/ fail sound
        }

        if (MinigameSuccess)
        {
            // play particles/ success sound
        }

        potionBehaviour.currentState = PotionBehaviour.CauldronState.Bottling;
        inputManager.SwitchToGameplay();
    }

    

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentButton.arrowDirection == MixButtons.Directions.LEFT)
            {
                EditArrow();
                NextArrow();
            }
            else return;
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentButton.arrowDirection == MixButtons.Directions.RIGHT)
            {
                EditArrow();
                NextArrow();
            }
            else return;
        }
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentButton.arrowDirection == MixButtons.Directions.UP)
            {
                EditArrow();
                NextArrow();
            }
            else return;
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentButton.arrowDirection == MixButtons.Directions.DOWN)
            {
                EditArrow();
                NextArrow();
            }
            else return;
        }
    }


    // https://www.youtube.com/watch?v=jwEPKY9poa4

    public void StartMiniGameEndDelay()
    {
        StartCoroutine(EndMiniGameAfterDelay());
    }

    private IEnumerator EndMiniGameAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);
        OnMinigameComplete();    
    }

}
