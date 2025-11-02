using UnityEngine;

public class CatTeleport : MonoBehaviour
{
    public GameObject CatTarot;
    public GameObject CatPotion;
    public GameObject CatRune;
    public GameObject CatCrystal;
    public GameObject CatTable;
    public GameObject CatStart;
    public GameObject CatEnd;

    public GameObject BedroomDoor;
    public GameObject PotionDoor;
    public GameObject RuneDoor;
    public GameObject CrystalDoor;

    public GameObject tarotCat;
    public GameObject potionCat;
    public GameObject runeCat;
    public GameObject crystalCat;

    public ParticleSystem TarotParticles;
    public ParticleSystem PotionParticles;
    public ParticleSystem RuneParticles;
    public ParticleSystem CrystalParticles;
    public ParticleSystem TableParticles;
    public ParticleSystem StartParticles;
    public ParticleSystem EndParticles;

    public GameObject TarotUI;

    public void Start()
    {
        SpawnCatTarot();
        SpawnCatStart();
    }

    public void SpawnCatTarot()
    {
        TarotParticles.Play();

        CatTarot.SetActive(true);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(true);
        RuneDoor.SetActive(true);
        CrystalDoor.SetActive(true);

       // tarotCat.SetActive(true);
        crystalCat.SetActive(false);
        runeCat.SetActive(false);
        potionCat.SetActive(false);
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

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
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);
        potionCat.SetActive(true);

        PotionParticles.Play();

       
        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(true);
        CrystalDoor.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
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
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        RuneParticles.Play();

        
        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(false);
        CrystalDoor.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
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
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        CrystalParticles.Play();

        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(false);
        CrystalDoor.SetActive(false);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
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
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        TableParticles.Play();
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
