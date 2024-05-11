using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartGame()
    {
        RoomController.roomNumbers = 0;
        SceneManager.LoadScene(1);
    }

    public void GoToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

}
