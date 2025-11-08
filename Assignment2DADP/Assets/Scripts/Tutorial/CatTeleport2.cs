using UnityEngine;

public class CatTeleport2 : MonoBehaviour
{
    public GameObject CatStart;
    public GameObject CatEnd;
    public ParticleSystem StartParticles;
    public ParticleSystem EndParticles;

    public GameObject TarotUI;
    public BedTrigger bed;

    public void Start()
    {
        SpawnCatStart();
    }

    public void SpawnCatStart()
    {
        StartParticles.Play();

        CatStart.SetActive(true);
        CatEnd.SetActive(false);
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);
    }

    public void SpawnCatEnd()
    {

        StartParticles.Play();

        CatStart.SetActive(false);
        CatEnd.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        EndParticles.Play();

    }
}
