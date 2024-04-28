using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    public static int roomNumber;
    public static int roomNumbers;
    private GameObject[] buttons;

    private void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
        Char[] arr = roomNumbers.ToString().ToCharArray();
        int temp = 0;
        foreach (GameObject button in buttons)
        {
            foreach (char c in arr)
            {
                if (button.name.Contains(c))
                {
                    button.SetActive(false);
                    temp++;
                }
            }
        }
        if (temp == 4)
            SceneManager.LoadScene(0);
    }

    public void EnterRoom()
    {
        SceneManager.LoadScene(roomNumber + 2);
    }

    public void GoBackToMenu()
    {
        print("back to menu");
        SceneManager.LoadScene(0);
    }

    public void PickRoom(int number)
    {
        roomNumber = number;
        roomNumbers = Int32.Parse(number.ToString() + roomNumbers.ToString());
    }

}
