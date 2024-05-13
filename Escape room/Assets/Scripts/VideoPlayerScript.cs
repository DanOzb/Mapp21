using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    private GameObject room;
    private GameObject skipButton;
    private new GameObject camera;
    private VideoPlayer videoPlayer;
    [SerializeField] VideoPlayer exitVideo; 

    private void Start()
    {
        room = GameObject.FindGameObjectWithTag("Room");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        skipButton = GameObject.FindGameObjectWithTag("Skip");
        playVideo();
    }

    //spelar videos
    void playVideo()
    {

        //spelar den f�rsta videon fr�n room
        videoPlayer = room.GetComponentInChildren<VideoPlayer>();
        
        if (videoPlayer == null)
        {
            //hittar QuestController som ska finnas i barnobjektet
            skipButton.SetActive(false);
            this.gameObject.transform.GetChild(0).GetComponent<QuestController>().Play(0);
        }
        else
        {
            videoPlayer.targetCamera = camera.GetComponent<Camera>();
            videoPlayer.Play();
            videoPlayer.loopPointReached += EndReached;
        }
    }

    //p�kallas av playvideo n�r videon har n�tt slutet
    void EndReached( VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        playVideo();
    }

    //tar emot en videoplayer, spelar den och kallar n�sta object fr�n QuestController
    public void PlayExtraVideos(VideoPlayer vp)
    {
        skipButton.SetActive(true);
        videoPlayer = vp;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += SetActiveFalse;
    }
    //s�tter objektet till false
    public void SetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
        skipButton.SetActive(false);
        this.gameObject.transform.GetChild(0).GetComponent<QuestController>().Play(1);
    }
    //s�tter videoplayer objektet till false
    public void SetActiveFalse(VideoPlayer vp)
    {
        SetActiveFalse(vp.gameObject);
    }
    //spolar fram framecount s� att EndReached p�kallas av playVideo
    public void SkipVideo()
    {
        ulong frameCount = videoPlayer.clip.frameCount - 1;
        videoPlayer.frame = (long) frameCount;
    }

    public void ExitVideo()
    {
        GameObject.FindGameObjectWithTag("Container").SetActive(false);
        skipButton.SetActive(true);
        videoPlayer = exitVideo;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += ExitReached;
    }

    void ExitReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }
}
