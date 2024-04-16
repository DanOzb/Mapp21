using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    private int scene; 
    public void EnterRoom()
    {
        SceneManager.LoadScene(scene);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PickRoom(int i)
    {
        scene = i;
    }
}
