using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] Animator transition;
    public float transitionsTime = 1f;

    public void StartGame()
    {
        RoomController.roomNumbers = 0;
        StartCoroutine(loadGame(1));
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

   
    IEnumerator loadGame(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTime);

        SceneManager.LoadScene(index);
    }
}
