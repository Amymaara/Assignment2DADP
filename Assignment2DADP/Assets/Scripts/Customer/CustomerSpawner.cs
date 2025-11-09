using UnityEngine;
using System.Collections;
// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
public class CustomerSpawner : MonoBehaviour
{
    [Header("Customer")]
    public DaySequence daySequence; //hold array of customers and what they want 
    public Transform spawnPoint; // sets spawn position for customers
    public float spawnDelay = 5f; // time before customer spawns in
    public bool autoSpawnOnStart = false;
    public ParticleSystem spawnParticle;
  


    [Header("Tarot")]

    private Customer currentCustomer;
    private int index = -1; // where you are in the queue, set to -1 so when SpawnNext() called goes to 0 
    private DaySequence.Entry currentEntry;
    private bool orderRevealed = false;
    public ObjectiveUI objectiveUI;

    private void Start()
    {
        //SpawnNext(); //immediately spawns customer for now (might change later)
        var timerBar = FindObjectOfType<TimerBar>();
        if (timerBar != null)
            timerBar.SetTotalCustomers(daySequence.queue.Length);

        Debug.Log("[Spawner] Start()");
        if (autoSpawnOnStart) SpawnNext();
    }

    public bool HasActiveCustomer => currentCustomer != null;
    public bool OrderRevealed => orderRevealed;

    public DaySequence.Entry CurrentEntry => currentEntry;

    public void StartDay()
    {
        index = -1;
        SpawnNext();
    }

    void SpawnNext()
    {
        index++; //move next slot if queue
        Debug.Log($"[Spawner] SpawnNext index={index}");

        if (daySequence == null || index >= daySequence.queue.Length)
        {
            Debug.Log("day finished");
            return;
        }

        currentEntry = daySequence.queue[index];
        orderRevealed = false;

        StartCoroutine(CustomerSpawnRoutine(currentEntry));
      
    }
    IEnumerator CustomerSpawnRoutine(DaySequence.Entry entry) //spawns the next customer
    {
        Debug.Log("[Spawner] Spawn coroutine start");
        yield return new WaitForSeconds(spawnDelay);
        currentCustomer = Instantiate(entry.customerPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log($"[Spawner] Spawned: {currentCustomer.name} at {spawnPoint.position}");

        {
            currentCustomer.SetOrder(entry.fixedOrder); // manually set order (turorial usage)
        }

        currentCustomer.OnServedCorrectly += HandleCustomerServed;
    }

    void HandleCustomerServed() //when customer served correctly goes to next customer and their event (order)
    {
        spawnParticle.Play();
        if (currentCustomer != null)
            currentCustomer.OnServedCorrectly -= HandleCustomerServed;

        objectiveUI?.HideObjectiveCard();
        FindObjectOfType<TimerBar>()?.CustomerServed();

        currentCustomer = null;
        SpawnNext();
    }

    public void MarkOrderRevealed()
    {
        orderRevealed = true;
    }
    public void DestroyCustomer() //destroys customer 
    {
        if (currentCustomer != null)
        {
            Destroy(currentCustomer.gameObject, 2f);
            currentCustomer = null;
            
        }
    }

}
