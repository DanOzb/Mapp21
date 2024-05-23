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

    public void StartGame()
    {
        RoomController.roomNumbers = 0;
        TransitionScript.sceneToLoad = 1;
        TransitionScript.nextTransition = true;
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
