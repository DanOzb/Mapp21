using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    private int roomNumber;
    public static int roomNumbers;
    private static int questNumbers;
    private List<int> roomList;
    [SerializeField] GameObject[] buttons;

    private void Start()
    {
        roomList = new List<int>();
        buttons = GameObject.FindGameObjectsWithTag("Button");
        Char[] arr = roomNumbers.ToString().ToCharArray();
        List<char> questArr = new List<char>();
        questArr.AddRange(questNumbers.ToString().ToCharArray());
        int temp = 0;

        for(int i = 0; i < 4; i++)
        {
            if (!questArr.Contains(((char)i)))
            {
                roomList.Add(i);
            }
        }

        foreach(char c in arr)
        {
            Debug.Log(c);
            int number = Int32.Parse(c.ToString());
            number--;
            if (number >= 0)
            {
                buttons[number].SetActive(false);
                temp++;
            }
        }
        if (temp == 4)
            SceneManager.LoadScene(0);

    }

    public void EnterRoom()
    {
        if (roomList.Count == 0)
            SceneManager.LoadScene(6); //rum 4
        roomNumber = roomList[UnityEngine.Random.Range(0, roomList.Count)]; //rum 1-3
        SceneManager.LoadScene(roomNumber + 2);
        Debug.Log(roomList.Count);
    }

    public void GoBackToMenu()
    {
        print("back to menu");
        SceneManager.LoadScene(0);
    }

    public void Room(int number)
    {
        roomNumbers = Int32.Parse(roomNumbers.ToString() + number.ToString());
    }

}
