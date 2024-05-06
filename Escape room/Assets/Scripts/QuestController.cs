using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestController : MonoBehaviour
{
    //Hittar questContainer, kollar om en quest finns och om den finns så aktiveras den
    public void Play(int index)
    {
        GameObject questObject = GameObject.FindGameObjectWithTag("Container");
        if (questObject.transform.childCount == 0)
            SceneManager.LoadScene(2);
        else
        {
            Debug.Log("child object with index " + index + " is getting called");
            questObject.transform.GetChild(index).gameObject.SetActive(true);
        }
    }
}
