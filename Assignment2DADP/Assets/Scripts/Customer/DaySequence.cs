using UnityEngine;

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
