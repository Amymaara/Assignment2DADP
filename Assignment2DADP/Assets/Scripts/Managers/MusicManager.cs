using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{

    public AudioClip audioClip;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.loop = true; 
        audioSource.playOnAwake = false;
        audioSource.volume = 0.1f;

        audioSource.Play();
    }
}
