using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestContainer : MonoBehaviour
{
    public GameObject questContainerPrefab; // Reference to the QuestContainer prefab

    public void OpenContainer()
    {
        Instantiate(questContainerPrefab, Vector3.zero, Quaternion.identity);
    }
}
