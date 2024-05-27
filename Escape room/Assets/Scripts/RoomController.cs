using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    private int roomNumber;
    public static int roomNumbers;
    private static int questNumbers;
    private List<int> leftQuestsList;
    [SerializeField] GameObject[] buttons;

    private void Start()
    {
        leftQuestsList = new List<int>();
        buttons = GameObject.FindGameObjectsWithTag("Button");

        Char[] arr = roomNumbers.ToString().ToCharArray();

        List<char> questNumbers = new List<char>();

        int temp = 0;


        for(int i = 1; i < 4; i++)
        {
            if (!questNumbers.Contains((char)i))
            {
                leftQuestsList.Add(i);
            }
        }

        foreach(char c in arr)
        {
            int number = Int32.Parse(c.ToString());
            number--;
            if (number >= 0)
            {
                buttons[number].SetActive(false);
                temp++;
            }
        }
        if (temp == 4)
            EnterRoom();

    }

    public void EnterRoom()
    {
        if (leftQuestsList.Count == 0)
            SceneManager.LoadScene(6); //rum 4
        roomNumber = leftQuestsList[UnityEngine.Random.Range(1, leftQuestsList.Count)];//rum 1-3
        questNumbers = Int32.Parse(questNumbers.ToString() + roomNumber);
        TransitionScript.sceneToLoad = roomNumber + 2;
        TransitionScript.nextTransition = true;
        Debug.Log(leftQuestsList.Count);
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
