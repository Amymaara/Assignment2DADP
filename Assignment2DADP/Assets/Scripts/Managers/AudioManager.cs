using UnityEngine;
using System;

[RequireComponent (typeof(AudioSource)), ExecuteInEditMode]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static AudioManager instance;
    private AudioSource audioSource;

    public enum SoundType
    {
        // list all sounds here in order assign to inspector
        FOOTSTEP,
        MINIGAMESUCCESS,
        MINIGAMEFAIL,
        POTIONBUBBLES,
        AMBIENCE
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
