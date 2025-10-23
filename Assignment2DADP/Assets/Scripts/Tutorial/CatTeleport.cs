using UnityEngine;

public class CatTeleport : MonoBehaviour
{
    public GameObject CatTarot;
    public GameObject CatPotion;
    public GameObject CatRune;
    public GameObject CatCrystal;
    public GameObject CatTable;

    public GameObject tarotCat;
    public GameObject potionCat;
    public GameObject runeCat;
    public GameObject crystalCat;

    public ParticleSystem TarotParticles;
    public ParticleSystem PotionParticles;
    public ParticleSystem RuneParticles;
    public ParticleSystem CrystalParticles;
    public ParticleSystem TableParticles;

    public GameObject TarotUI;

    public void Start()
    {
        SpawnCatTarot();
    }

    public void SpawnCatTarot()
    {
        TarotParticles.Play();

        CatTarot.SetActive(true);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

       // tarotCat.SetActive(true);
        crystalCat.SetActive(false);
        runeCat.SetActive(false);
        potionCat.SetActive(false);

    }


    public void SpawnCatPotion()
    {
        TarotParticles.Play();

        CatTarot.SetActive(false);
        CatPotion.SetActive(true);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        tarotCat.SetActive(false);
        crystalCat.SetActive(false);
        runeCat.SetActive(false);
        potionCat.SetActive(true);

        PotionParticles.Play();
    }

    public void SpawnCatRune()
    {
        PotionParticles.Play();

        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(true);
        CatCrystal.SetActive(false);

        tarotCat.SetActive(false);
        crystalCat.SetActive(false);
        runeCat.SetActive(true);
        potionCat.SetActive(false);

        RuneParticles.Play();
    }

    public void SpawnCatCrystal()
    {
        RuneParticles.Play();
        
        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(true);

        tarotCat.SetActive(false);
        crystalCat.SetActive(true);
        runeCat.SetActive(false);
        potionCat.SetActive(false);

        CrystalParticles.Play();
    }
    public void SpawnCatTable()
    {
       CrystalParticles.Play();

        TarotUI.SetActive(false);
        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(true);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        tarotCat.SetActive(false);
        crystalCat.SetActive(false);
        runeCat.SetActive(false);
        potionCat.SetActive(false);

        TableParticles.Play();
    }

}
