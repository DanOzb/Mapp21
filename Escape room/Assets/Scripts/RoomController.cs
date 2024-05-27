using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    private int questNumber;
    public static int roomNumbers;
    private static int questNumbers;
    private List<int> leftQuestsList;
    [SerializeField] GameObject[] buttons;

    private void Start()
    {
        leftQuestsList = new List<int>();

        Char[] arr = roomNumbers.ToString().ToCharArray();

        List<char> questNumbersList = new List<char>((char) questNumbers);

        int temp = 0;


        for(int i = 1; i < 4; i++)
        {
            if (!questNumbersList.Contains((char)i))
            {
                leftQuestsList.Add(i);
            }
        }

        foreach (char c in arr)
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
        shuffle();
        if (leftQuestsList.Count == 0)
            SceneManager.LoadScene(6); //rum 4

        questNumber = leftQuestsList[0];
        questNumbers = Int32.Parse(questNumbers.ToString() + questNumber);

        Debug.Log("quest: " + questNumbers);

        TransitionScript.sceneToLoad = questNumber + 2;
        TransitionScript.nextTransition = true;
    }

    public void GoBackToMenu()
    {
        print("back to menu");
        SceneManager.LoadScene(0);
    }

    public void Room(int number)
    {
        roomNumbers = Int32.Parse(roomNumbers.ToString() + number.ToString());
        Debug.Log(roomNumbers);
    }

    private void shuffle()
    {
        System.Random random = new System.Random();
        int index = leftQuestsList.Count;
        while(index > 1)
        {
            index--;
            int index2 = random.Next(index + 1);
            int value = leftQuestsList[index2];
            leftQuestsList[index2] = leftQuestsList[index];
            leftQuestsList[index] = value;
        }
    }

}
