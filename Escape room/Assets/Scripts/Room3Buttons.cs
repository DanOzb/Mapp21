using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room3Buttons : MonoBehaviour
{
    public void BluePill()
        //B�rja om fr�n b�rjan
    {
        RoomController.roomNumber = 1;
        RoomController.roomNumbers = 0;
        SceneManager.LoadScene(1);
    }

    public void RedPill()
        //G� vidare till ChooseRoom 4
    {
        SceneManager.LoadScene(2);
    }
}