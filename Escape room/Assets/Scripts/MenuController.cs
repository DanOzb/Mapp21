using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    public void StartGame()
    {
        RoomController.roomNumber = 1;
        SceneManager.LoadScene(1);
    }

    
    public void QuitGame()
    {
        Application.Quit();
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
