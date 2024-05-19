using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Room4 : MonoBehaviour
{
    [SerializeField] VideoPlayer endingA, endingB, endingC;
    [SerializeField] GameObject endingAScreen, endingBScreen, endingCScreen, videoController;

    [SerializeField] GameObject canvas;
    private float videoLength;
    private string ending;

    public void OptionA()
    {
        videoController.SetActive(false);
        canvas.SetActive(false);
        if(endingA.clip != null)
        {
            endingA.gameObject.SetActive(true);
            ending = "A";
            videoLength = (float)(endingA.clip.length + 0.5);
            endingA.Play();
            Invoke("EndReached", videoLength);
        }
        else
        {
            endingAScreen.SetActive(true);
        }
        
    }

    public void OptionB()
    {
        videoController.SetActive(false);
        canvas.SetActive(false);
        if (endingB.clip != null)
        {
            endingB.gameObject.SetActive(true);
            ending = "B";
            videoLength = (float)(endingB.clip.length + 0.5);
            endingB.Play();
            Invoke("EndReached", videoLength);
        } else
        {
            endingBScreen.SetActive(true);
        }
        
    }

    public void OptionC()
    {
        videoController.SetActive(false);
        canvas.SetActive(false);
        if (endingC.clip != null)
        {
            endingC.gameObject.SetActive(true);
            ending = "C";
            videoLength = (float)(endingC.clip.length + 0.5);
            endingC.Play();
            Invoke("EndReached", videoLength);
        } else
        {
            endingCScreen.SetActive(true);
        }

    }

    //spelar en video innan game over screen
    private void EndReached()
    {
        switch (ending)
        {
            case "A":
                endingA.gameObject.SetActive(false);
                endingAScreen.SetActive(true);
                break;
            case "B":
                endingB.gameObject.SetActive(false);
                endingBScreen.SetActive(true);
                break;
            case "C":
                endingC.gameObject.SetActive(false);
                endingCScreen.SetActive(true);
                break;
        }
    }
}
