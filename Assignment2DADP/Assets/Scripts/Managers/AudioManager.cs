using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;

// audio manager system
// Title: PLEASE use a Unity SOUND MANAGER! — Full Tutorial
// Author: Brackeys 2.0
// Date Accessed: 9 October 2025
// Accessibility: https://www.youtube.com/watch?v=g5WT91Sn3hg&t=337s

[RequireComponent (typeof(AudioSource)), ExecuteInEditMode]

public class AudioManager : MonoBehaviour
{
   
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] private bool debugLogs = false;

    public static AudioManager instance { get; private set; }
    public AudioSource audioSource;
    

    public enum SoundType
    {
        // list all sounds here in order assign to inspector
        FOOTSTEP,
        MINIGAMESUCCESS,
        MINIGAMEFAIL,
        POTIONBUBBLES,
        POTIONFILL,
        RUNEDRAW,
        FLIPCARD,
        BUTTON,
        PICKUP,
        DOOROPEN,
        DOORCLOSE,
        QUESTSUCCESS,
        MEOW
    }
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (audioSource == null) 
        {
            audioSource = GetComponent<AudioSource>();
        }

        //audioSource = GetComponent<AudioSource>();
    }

    /* Little guide on how audio works:
     use AudioManager.PlaySound(AudioManager.SoundType.(name); => one shot
     use AudioManager.PlaySound(AudioManager.SoundType.(name),(volume), true); => loop
     use AudioManager.StopSound(); => stop looping sounds
    */
    public static void PlaySound(SoundType sound, float volume = 0.1f, bool loop = false)
    {

        //instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);

        if (instance == null || instance.soundList == null)
        {
            Debug.LogWarning("Audiomanager not initialised or soundlist missing");
            return;
        }

        AudioClip clip = instance.soundList[(int)sound];
        if (clip == null)
        {
            Debug.LogWarning($"sound clip missing for {sound}");
            return;
        }

        if (loop)
        {
            instance.audioSource.clip = clip;
            instance.audioSource.volume = volume;
            instance.audioSource.loop = true;
            instance.audioSource.Play();
        }

        else
        {
            instance.audioSource.PlayOneShot(clip, volume);
        }
    }

    public static void StopSound()
    {
        if (instance == null || instance.audioSource == null) return;
        instance.audioSource.Stop();
    }

    public void AudioVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
