using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room3Buttons : MonoBehaviour
{
    public void BluePill()
        //B�rja om fr�n b�rjan
    {
        SceneManager.LoadScene(1);
    }

    public void RedPill()
        //G� vidare till ChooseRoom 4
    {
        SceneManager.LoadScene(2);
    }
}
