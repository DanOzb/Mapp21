using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Quest4 : MonoBehaviour
{
    private bool dead = false;
    [SerializeField] GameObject videoController, questContainer;
    [SerializeField] VideoPlayer redPill, bluePill;
    private float videoLength;

    public void BluePill()
        //Börja om från början
    {
        dead = true;
        questContainer.SetActive(false);
        videoLength = (float) (bluePill.clip.length + 0.5);
        bluePill.Play();
        Invoke("EndReached", videoLength);
    }

    public void RedPill()
        //Gå vidare till ChooseRoom 4
    {
        questContainer.SetActive(false);
        videoLength = (float) (redPill.clip.length + 0.5);
        redPill.Play();
        Invoke("EndReached", videoLength );
    }

    public void EndReached()
    {
        if (dead)
        {
            bluePill.gameObject.SetActive(false);
            RoomController.roomNumbers = 0;
            SceneManager.LoadScene(1);
        } else
        {
            redPill.gameObject.SetActive(false);
            videoController.GetComponent<VideoPlayerScript>().ExitVideo();
        }
    }
   
}
