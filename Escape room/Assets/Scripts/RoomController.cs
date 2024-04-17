using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    public static int roomNumber;
    public void EnterRoom()
    {
        SceneManager.LoadScene(2);
    }

    public void GoBackToMenu()
    {
        print("back to menu");
        SceneManager.LoadScene(0);
    }

    public void PickRoom(int number)
    {
        roomNumber = number;
    }

}
