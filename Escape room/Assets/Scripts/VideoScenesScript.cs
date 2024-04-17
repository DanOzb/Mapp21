using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScenesScript : MonoBehaviour
{
    int counter = 0;
    private int roomNumber;
    [SerializeField] GameObject[] roomOne, roomTwo, RoomThree, RoomFour;
    private GameObject[][] rooms;
    void Start()
    {
        rooms = new GameObject[][] { roomOne, roomTwo, RoomThree, RoomFour };
        roomNumber = RoomController.roomNumber - 1;
        rooms[roomNumber][counter].SetActive(true);
        if(roomNumber == 0)
        {
            Invoke("LoopMethod", 9);
        } else
        {
            Invoke("LoopMethod", 4);
        }
        
    }

    void LoopMethod()
    {
        if(counter == rooms[roomNumber].Length - 1) 
        {
            SceneManager.LoadScene(0);

        }
        else
        {
            NextScene();
        }
       
    }

    void NextScene()
    {
        rooms[roomNumber][counter].SetActive(false);
        rooms[roomNumber][counter+1].SetActive(true);
        counter++;
        Invoke("LoopMethod", 4);
    }
}
