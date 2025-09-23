using UnityEngine;

public class CatTeleport : MonoBehaviour
{
    public GameObject Cat;
    public GameObject CatPotion;
    public GameObject CatTable;

    public ParticleSystem CounterParticles;
    public ParticleSystem PotionParticles;
    public ParticleSystem TableParticles;

    public GameObject TarotUI;

    public void Start()
    {
        SpawnCatCounter();
    }

    public void SpawnCatCounter()
    {
        CounterParticles.Play();
        Cat.SetActive(true);
       CatPotion.SetActive(false);
        CatTable.SetActive(false);
    }


    public void SpawnCatPotion()
    {
        CounterParticles.Play();
        Cat.SetActive(false);
        CatPotion.SetActive(true);

        PotionParticles.Play();
    }


    public void SpawnCatTable()
    {
        TarotUI.SetActive(false);
        PotionParticles.Play();
        CatPotion.SetActive(false);
        CatTable.SetActive(true);
        TableParticles.Play();
    }

}
