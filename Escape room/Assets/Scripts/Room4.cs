using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Room4 : MonoBehaviour
{
    [SerializeField] GameObject endingAScreen, endingBScreen, endingCScreen, videoController; 

    [SerializeField] GameObject canvas;
    public string ending = "";

    public void SetVideo(string AToC) 
    {
        ending = AToC;
        
    }

    //spelar en video innan game over screen
    public void EndReached()
    {
        switch (ending)
        {
            case "A":
                endingAScreen.SetActive(true);
                ending = "";
                break;
            case "B":
                endingBScreen.SetActive(true);
                ending = "";
                break;
            case "C":
                endingCScreen.SetActive(true);
                ending = "";
                break;
        }
    }
}
