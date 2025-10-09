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
        public ItemSO fixedOrder;

        public Sprite tarotCard1; // how they died
        public Sprite tarotCard2; // what they want
        public Sprite tarotCard3; // why they need it
    }

    public string dayName = "Day X";
    public Entry[] queue;
}
