using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room4 : MonoBehaviour
{
    public void OptionA()
    {
        SceneManager.LoadScene(7);
    }

    public void OptionB()
    {
        SceneManager.LoadScene(8);
    }

    public void OptionC()
    {
        SceneManager.LoadScene(9);
    }
}
