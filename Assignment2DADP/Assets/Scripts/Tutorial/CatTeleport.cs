using UnityEngine;

public class CatTeleport : MonoBehaviour
{
    [Header("NPC")]
    public GameObject CatTarot;
    public GameObject CatPotion;
    public GameObject CatRune;
    public GameObject CatCrystal;
    public GameObject CatTable;

    [Header("Doors")]
    public GameObject BedroomDoor;
    public GameObject PotionDoor;
    public GameObject RuneDoor;
    public GameObject CrystalDoor;

    [Header("Particles")]
    public ParticleSystem TarotParticles;
    public ParticleSystem PotionParticles;
    public ParticleSystem RuneParticles;
    public ParticleSystem CrystalParticles;
    public ParticleSystem TableParticles;

    [Header("Tarot")]
    public GameObject tarotDeck;
    public GameObject PotionDeck;
    public GameObject RuneDeck;
    public GameObject CrystalDeck;

    public GameObject TarotUI;
    public BedTrigger bed;
    public CandleManager candleManager;

    public void Start()
    {
        SpawnCatTarot();
        
    }

    public void SpawnCatTarot()
    {
        candleManager.TurnOnFrontCandles();

        TarotParticles.Play();

        // npc
        CatTarot.SetActive(true);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        // doors
        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(true);
        RuneDoor.SetActive(true);
        CrystalDoor.SetActive(true);

        // tarot
        tarotDeck.SetActive(true);
        PotionDeck.SetActive(false);
        RuneDeck.SetActive(false);
        CrystalDeck.SetActive(false);

        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

    }


    public void SpawnCatPotion()
    {
        candleManager.TurnOffFrontCandles();
        candleManager.TurnOnPotionCandles();

        TarotParticles.Play();

        CatTarot.SetActive(false);
        CatPotion.SetActive(true);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        PotionParticles.Play();

        // tarot
        tarotDeck.SetActive(false);
        PotionDeck.SetActive(true);
        RuneDeck.SetActive(false);
        CrystalDeck.SetActive(false);

        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(true);
        CrystalDoor.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
    }

    public void SpawnCatRune()
    {
        candleManager.TurnOffPotionCandles();
        candleManager.TurnOnRuneCandles();

        PotionParticles.Play();

        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(true);
        CatCrystal.SetActive(false);

        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        RuneParticles.Play();

        // tarot
        tarotDeck.SetActive(false);
        PotionDeck.SetActive(false);
        RuneDeck.SetActive(true);
        CrystalDeck.SetActive(false);

        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(false);
        CrystalDoor.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
    }

    public void SpawnCatCrystal()
    {
        candleManager.TurnOffRuneCandles();
        candleManager.TurnOnCrystalCandles();
        
        RuneParticles.Play();
        
        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(false);
        CatRune.SetActive(false);
        CatCrystal.SetActive(true);
        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        CrystalParticles.Play();

        // tarot
        tarotDeck.SetActive(false);
        PotionDeck.SetActive(false);
        RuneDeck.SetActive(false);
        CrystalDeck.SetActive(true);

        BedroomDoor.SetActive(false);
        PotionDoor.SetActive(false);
        RuneDoor.SetActive(false);
        CrystalDoor.SetActive(false);
        AudioManager.PlaySound(AudioManager.SoundType.DOOROPEN, 0.1f);
    }
    public void SpawnCatTable()
    {
        candleManager.TurnOffCrystalCandles();
        candleManager.TurnOnFrontCandles();

       CrystalParticles.Play();

        TarotUI.SetActive(false);
        CatTarot.SetActive(false);
        CatPotion.SetActive(false);
        CatTable.SetActive(true);
        CatRune.SetActive(false);
        CatCrystal.SetActive(false);

        // tarot
        tarotDeck.SetActive(false);
        PotionDeck.SetActive(false);
        RuneDeck.SetActive(false);
        CrystalDeck.SetActive(false);

        AudioManager.PlaySound(AudioManager.SoundType.MEOW, 0.1f);

        TableParticles.Play();
        bed.canInteract = true; 
    }
}
