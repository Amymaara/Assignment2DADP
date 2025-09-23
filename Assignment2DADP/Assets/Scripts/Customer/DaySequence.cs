using UnityEngine;

// quest system 
// Title: How create a Quest System in Unity | RPG Style | Including Data Persistence
// Author: Shaped by Rain Studios
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=UyTJLDGcT64&t=3634s
[CreateAssetMenu(menuName = "DaySequence")]
public class DaySequence : ScriptableObject
{
    [System.Serializable]

    public struct Entry
    {
        public Customer customerPrefab;
        public bool orderFromTarot;
        public ItemSO fixedOrder;
    }

    public string dayName = "Day X";
    public Entry[] queue;
}
