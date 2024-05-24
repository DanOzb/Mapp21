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
    public static bool dead = false;
    [SerializeField] GameObject videoController, questContainer;

    public void Dead()
    {
        dead = true;
    }

    public void EndReached()
    {
        if (dead)
        {
            RoomController.roomNumbers = 0;
            TransitionScript.sceneToLoad = 1;
            TransitionScript.nextTransition = true;
            dead = false;
        } else
        {
            videoController.GetComponent<VideoPlayerScript>().ExitVideo();
        }
    }
   
}
