using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static AudioManager;

public class TitleScreen : MonoBehaviour
{
    public GameObject firstButton;
    public UINavigationManager navigationManager;

    public AudioClip buttonSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;
    }

    private void OnEnable()
    {
        navigationManager.firstSelected = firstButton;
    }

    public void OnExitGame()
    {
        PlaySoundAndQuit();
    }

    public void PlayGame()
    {
        PlaySoundAndLoad("Tutorial Day");
    }

    private void PlaySoundAndQuit()
    {
        StartCoroutine(PlayThenDo(() => Application.Quit()));
    }

    private void PlaySoundAndLoad(string sceneName)
    {
        StartCoroutine(PlayThenDo(() => SceneManager.LoadScene(sceneName)));
    }

    private IEnumerator PlayThenDo(System.Action action)
    {
        if (buttonSound && audioSource)
        {
            audioSource.PlayOneShot(buttonSound);
            yield return new WaitForSeconds(buttonSound.length); 
        }

        action?.Invoke();
    }
}
