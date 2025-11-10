using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class SceneIntroVideoManager : MonoBehaviour
{
   
    public VideoPlayer videoPlayer;
    public float playDuration = 2f; 

    private bool isPlaying = false;

    void Awake()
    {
        StartCoroutine(PlayIntroClip());
    }

    

    IEnumerator PlayIntroClip()
    {
        if (isPlaying) yield break;
        isPlaying = true;

        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return null;

        videoPlayer.Play();

        yield return new WaitForSeconds((float)playDuration);

        videoPlayer.Stop();

        isPlaying = false;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}