using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    private bool videoPlayed = false;
    private GameObject room;
    private GameObject skipButton;
    private new GameObject camera;
    private VideoPlayer videoPlayer;
    [SerializeField] VideoPlayer exitVideo;
    [SerializeField] VideoPlayer[] extraVideo; //index 0 == comply video. index 1 == rage video
    [SerializeField] GameObject pauseMenu;

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

        //spelar den första videon från room
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

    //påkallas av playvideo när videon har nått slutet
    void EndReached( VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        playVideo();
    }

    //tar emot en videoplayer, spelar den och kallar nästa object från QuestController
    public void PlayExtraVideos(GameObject obj)
    {
        obj.SetActive(false);
        skipButton.SetActive(true);
        videoPlayer = extraVideo[QuestController.rageOrComply];
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += SetActiveFalse;

    }

    //sätter videoplayer objektet till false
    public void SetActiveFalse(VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        skipButton.SetActive(false);
        this.gameObject.transform.GetChild(0).GetComponent<QuestController>().Play(1);

    }
    //spolar fram framecount så att EndReached påkallas av playVideo
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

    public void pauseGame()
    {
        videoPlayer.Pause();
        pauseMenu.SetActive(true);
    }


    public void resumeGame()
    {
        videoPlayer.Play();
        pauseMenu.SetActive(false);
    }
}
