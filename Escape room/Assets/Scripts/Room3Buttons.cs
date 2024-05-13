using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Room3Buttons : MonoBehaviour
{
    [SerializeField] GameObject videoController;
    public void BluePill()
        //Börja om från början
    {
        RoomController.roomNumbers = 0;
        SceneManager.LoadScene(1);
    }

    public void RedPill()
        //Gå vidare till ChooseRoom 4
    {
        videoController.GetComponent<VideoPlayerScript>().ExitVideo();
    }


}
