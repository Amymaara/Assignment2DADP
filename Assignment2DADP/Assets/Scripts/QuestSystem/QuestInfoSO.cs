using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// customer spawning help from this video
// Title: Unity- RPG Hero Diner - Customer Spawning
// Author: Design and Deploy
// Date Accessed: 23 September 2025
// Accesibility: https://www.youtube.com/watch?v=vI7VLNuyhpU&t=661s

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "Scriptable Objects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string id {  get; private set; }

    [Header("General")]
    public string displayName;

    [Header("Requirements")]
    public QuestInfoSO[] questPrerequisite;

    [Header("Steps")]
    public GameObject[] questStepPrefabs;
    // ensures id always the name of the SO asset


    private void OnValidate()
    {
#if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
