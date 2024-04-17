using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestsManager : MonoBehaviour
{
    [SerializeField] GameObject[] questRooms;
    private int room;
    void Start()
    {
        room = RoomController.roomNumber - 1;
        openQuest(room);
    }

    void openQuest(int room)
    {
        questRooms[room].SetActive(true);
        //ändra senare
        if(room > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
