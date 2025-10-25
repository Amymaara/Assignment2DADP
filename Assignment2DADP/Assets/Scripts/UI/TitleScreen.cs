using UnityEngine;
using UnityEngine.SceneManagement;
using static AudioManager;

public class TitleScreen : MonoBehaviour
{
    

    public GameObject firstButton;

    public UINavigationManager navigationManager;




   

   

    private void OnEnable()
    {
     
        navigationManager.firstSelected = firstButton;
  

    }



    public void OnExitGame()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Blocking");
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

    }
}
