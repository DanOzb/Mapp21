using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void RestartGame()
    {
        RoomController.roomNumber = 1;
        RoomController.roomNumbers = 0;
        SceneManager.LoadScene(1);
    }
}
