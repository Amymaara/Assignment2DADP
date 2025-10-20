using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static AudioManager;

public class CrystalMinigame : MonoBehaviour
{
    // i used this tutorial to do the progress bar, the other parts are my own code
    // Title: How To Make Radial Circular Progress Bar in Unity 2D
    // Author: Code Cyber
    // Date Accesed: 12 October 2025
    // Accesibility: https://www.youtube.com/watch?v=Lpq4aXvl7xg&t=36s

    public Sprite success;
    public Sprite failure;

    public Image North;
    public Image East;
    public Image West;
    public Image South;

    public InputManager inputManager;

    public int CorrectPillars;

    public Image ProgressBar;
    [SerializeField] float speed;
    float currentValue;

    int buttonsPressed = 0;

    public CrystalBehaviours behaviours;
    public ParticleSystem successParticles;
    public ParticleSystem failureParticles;
   

    private void OnEnable()
    {
        ProgressBar.fillAmount = 0;
        currentValue = 0;
        CorrectPillars = 0;
        North.gameObject.SetActive(false);
        East.gameObject.SetActive(false);
        West.gameObject.SetActive(false);
        South.gameObject.SetActive(false);
        buttonsPressed = 0;
        
    }

    private void OnDisable()
    {
        ProgressBar.fillAmount = 0;
        currentValue = 0;
        CorrectPillars = 0;
        North.gameObject.SetActive(false);
        East.gameObject.SetActive(false);
        West.gameObject.SetActive(false);
        South.gameObject.SetActive(false);
        buttonsPressed = 0;
    }

    private void Update()
    {
        if (currentValue < 1) 
        {
            currentValue += speed * Time.deltaTime;

        }
        else
        {
            // minigame done
            if (CorrectPillars == 4)
            {
                successParticles.Play();
                AudioManager.PlaySound(SoundType.MINIGAMESUCCESS, 0.1f);
            }
            else
            {
                failureParticles.Play();
                AudioManager.PlaySound(SoundType.MINIGAMEFAIL, 0.1f);
                behaviours.CrystalRecipe = CrystalBehaviours.Recipe.None;
            }
            
            behaviours.ResetWorkstations();
            behaviours.GetCrystal();
            inputManager.SwitchToGameplay();
        }

        ProgressBar.fillAmount = currentValue;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonsPressed++;
            AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

            if (buttonsPressed == 1)
            {
                CheckButton1();
            }
            else if (buttonsPressed == 2)
            {
                CheckButton2();
            }
            else if (buttonsPressed == 3)
            {
                CheckButton3();
            }
            else if (buttonsPressed == 4)
            {
                CheckButton4();
            }
            else return;
        }
    }

    void CheckButton1()
    {
        if(currentValue > 0.13 && currentValue < 0.21)
        {
            CorrectPillars++;
            East.gameObject.SetActive(true);
            East.sprite = success;
        }
        else
        {
            East.gameObject.SetActive(true);
            East.sprite = failure;
        }
    }

    void CheckButton2()
    {
        if (currentValue > 0.36 && currentValue < 0.46)
        {
            CorrectPillars++;
            South.gameObject.SetActive(true);
            South.sprite = success;
        }
        else
        {
            South.gameObject.SetActive(true);
            South.sprite = failure;
        }
    }

    void CheckButton3()
    {
        if (currentValue > 0.63 && currentValue < 0.71)
        {
            CorrectPillars++;
            West.gameObject.SetActive(true);
            West.sprite = success;
        }
        else
        {
            West.gameObject.SetActive(true);
            West.sprite = failure;
        }
    }

    void CheckButton4()
    {
        if (currentValue > 0.86 && currentValue < 0.96)
        {
            CorrectPillars++;
            North.gameObject.SetActive(true);
            North.sprite = success;
        }
        else
        {
            North.gameObject.SetActive(true);
            North.sprite = failure;
        }
    }



}
