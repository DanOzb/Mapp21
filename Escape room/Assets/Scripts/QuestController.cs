using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestController : MonoBehaviour
{
    public static int rageOrComply = 0;
    private GameObject levelLoader, questObject;

    private void Start()
    {
        questObject = GameObject.FindGameObjectWithTag("Container");
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
    }

    //Hittar questContainer, kollar om en quest finns och om den finns så aktiveras den
    public void Play(int index)
    {
        if (questObject.transform.childCount == 0)
            levelLoader.GetComponent<TransitionScript>().LoadScene(2);
        else
        {
            questObject.transform.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void Rage(bool rage)
    {
        if (rage)
            rageOrComply++;
    }
}
