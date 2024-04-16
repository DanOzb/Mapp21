using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    
    public void EnterRoom()
    {
        SceneManager.LoadScene(2);
    }

    
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
