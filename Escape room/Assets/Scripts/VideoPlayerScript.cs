using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    private GameObject questContainer, camera, skipButton, room;
    VideoPlayer questVideo;
    private VideoPlayer videoPlayer;
    [SerializeField] VideoPlayer exitVideo;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Animator transition;
    private List<AudioSource> allAudioSources;
    private bool _isPressed = false;

    private void Start()
    {
        room = GameObject.FindGameObjectWithTag("Room");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        skipButton = GameObject.FindGameObjectWithTag("Skip");
        questContainer = GameObject.FindGameObjectWithTag("Container");

        allAudioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
        PlayVideo();
    }

    private void Update()
    {
        if(PauseMenu._pause && !pauseMenu.activeSelf)
            pauseGame();
        else if(!PauseMenu._pause && pauseMenu.activeSelf)
            resumeGame();

    }



    //spelar videos
    void PlayVideo()
    {

        //spelar den första videon från room
        videoPlayer = room.GetComponentInChildren<VideoPlayer>();

        if (videoPlayer == null)
        {
            if (!(questContainer.transform.GetChild(0).tag == "Quest") &&
                questContainer.transform.GetChild(0).GetComponentInChildren<VideoPlayer>() != null)
            {
                questVideo = questContainer.transform.GetChild(0).GetComponentInChildren<VideoPlayer>();
            }
            if (skipButton != null)
                skipButton.SetActive(false);
            //hittar QuestController som ska finnas i barnobjektet
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
    void EndReached(VideoPlayer vp)
    {
        Debug.Log("End reached");
        videoPlayer.gameObject.SetActive(false);
        transition.SetTrigger("Transition");
        PlayVideo();
    }

    //tar emot en videoplayer, spelar den och kallar nästa object från QuestController
    public void PlayExtraVideos(VideoPlayer vp)
    {
        Debug.Log("play");
        transition.SetTrigger("Transition");
        questContainer.transform.GetChild(0).gameObject.SetActive(false);
        skipButton.SetActive(true);
        videoPlayer = vp;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += SetActiveFalse;
    }

    //sätter videoplayer objektet till false
    public void SetActiveFalse(VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        skipButton.SetActive(false);
        transition.SetTrigger("Transition");
        int scene = SceneManager.GetActiveScene().buildIndex;
        switch (scene)
        {
            case 5:
                questContainer.transform.GetChild(0).GetComponent<Quest4>().EndReached();
                break;
            case 6:
                questContainer.transform.GetChild(0).GetComponent<Room4>().EndReached();
                break;
            default:
                if (questContainer.transform.childCount >= 1)
                    this.transform.GetChild(0).GetComponent<QuestController>().Play(1);
                break;
        }

    }
    //spolar fram framecount så att EndReached påkallas av playVideo
    public void SkipVideo()
    {
        ulong frameCount = videoPlayer.clip.frameCount - 1;
        videoPlayer.frame = (long) frameCount;
    }

    public void FastForward()
    {
        _isPressed = _isPressed ? false : true;
        videoPlayer.Pause();
        if( _isPressed )
        {
            videoPlayer.playbackSpeed = 4;
            videoPlayer.Play();
        } else
        {
            videoPlayer.playbackSpeed = 1;
            videoPlayer.Play();
        }
    }

    public void ExitVideo()
    {
        transition.SetTrigger("Transition");
        GameObject.FindGameObjectWithTag("Container").SetActive(false);
        skipButton.SetActive(true);
        videoPlayer = exitVideo;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += ExitReached;
    }

    void ExitReached(VideoPlayer vp)
    {
        TransitionScript.sceneToLoad = 2;
        TransitionScript.nextTransition = true;
    }

    public void pauseGame()
    {
        if(videoPlayer != null)
            videoPlayer.Pause();
        else if(questVideo != null)
            questVideo.Pause();
        
        pauseMenu.SetActive(true);
        PauseAllAudio();
    }

    public void resumeGame()
    {
        if(videoPlayer != null)
            videoPlayer.Play();
        else 
            questVideo.Play();
        pauseMenu.SetActive(false);
        ResumeAllAudio();
    }

    private void PauseAllAudio()
    {
        foreach (AudioSource audio in allAudioSources)
        {
            if (audio.isPlaying)
            {
                audio.Pause();
            }
        }
    }

    private void ResumeAllAudio()
    {
        foreach (AudioSource audio in allAudioSources)
        {
            if (audio.time > 0)
            {
                audio.UnPause();
            }
        }
    }
}
