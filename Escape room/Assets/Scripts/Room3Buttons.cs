using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room3Buttons : MonoBehaviour
{
    public void BluePill()
        //Börja om från början
    {
        SceneManager.LoadScene(1);
    }

    public void RedPill()
        //Gå vidare till ChooseRoom 4
    {
        SceneManager.LoadScene(2);
    }
}
