using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
        StartCoroutine(EnableAfterDelay());
        Application.Quit();
    }

    public void PlayGame()
    {
        AudioManager.PlaySound(SoundType.BUTTON, 0.1f);
        StartCoroutine(EnableAfterDelay());
        SceneManager.LoadScene("Blocking");
        //AudioManager.PlaySound(SoundType.BUTTON, 0.1f);

    }

  
private IEnumerator EnableAfterDelay()
{
    
    yield return new WaitForSeconds(0.1f);
   
}
}
