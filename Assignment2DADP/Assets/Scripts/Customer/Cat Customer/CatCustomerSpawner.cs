using UnityEngine;
using System.Collections;
// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
public class CatCustomerSpawner : MonoBehaviour
{
    [Header("Customer")]
    public DaySequence daySequence; //hold array of customers and what they want 

    [Header("Tarot")]

    private Customer currentCustomer;
    private int index = -1; // where you are in the queue, set to -1 so when SpawnNext() called goes to 0 
    private DaySequence.Entry currentEntry;
    private bool orderRevealed = false;
    public ObjectiveUI objectiveUI;

    private void Start()
    {
        //SpawnNext(); //immediately spawns customer for now (might change later)

        Debug.Log("[Spawner] Start()");
        SpawnNext();
    }

    public bool HasActiveCustomer => currentCustomer != null;
    public bool OrderRevealed => orderRevealed;

    public DaySequence.Entry CurrentEntry => currentEntry;

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

        StartCoroutine(CustomerHandler(currentEntry));

    }
   

    private void ResidentCat()
    {

    }

    IEnumerator CustomerHandler(DaySequence.Entry entry)
    {
        yield return new WaitForSeconds(0.5f);
        currentCustomer = 
        currentCustomer.SetOrder(entry.fixedOrder);
        currentCustomer.OnServedCorrectly += HandleCustomerServed;
    }

    void HandleCustomerServed() //when customer served correctly goes to next customer and their event (order)
    {
        if (currentCustomer != null)
            currentCustomer.OnServedCorrectly -= HandleCustomerServed;

        objectiveUI?.HideObjectiveCard();

        currentCustomer = null;
        SpawnNext();
    }

    public void MarkOrderRevealed()
    {
        orderRevealed = true;
    }
}
