using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

//För att få scriptet att fungera, byt inte namn på spel objekten
//som håller videoplayers och video klipp.
public class VideoPlayerScript : MonoBehaviour
{
    private int roomNumber = RoomController.roomNumber - 1;
    private GameObject[] rooms;
    private GameObject room;
    private new GameObject camera;
    private VideoPlayer videoPlayer;
    [SerializeField] GameObject[] extraVideos; 

    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        camera = GameObject.Find("Main Camera");
        //sätter rätt rum till room
        foreach (GameObject rm in rooms)
        {
            if (rm.name.Contains((roomNumber + 1).ToString()))
                room = rm;
        }
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
    public void PlayExtraVideos(VideoPlayer vp)
    {
        videoPlayer = vp;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += SetActiveFalse;
        this.gameObject.transform.GetChild(0).GetComponent<QuestController>().Play(1);
    }
    //sätter objektet till false
    public void SetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
    }
    //sätter videoplayer objektet till false
    public void SetActiveFalse(VideoPlayer vp)
    {
        SetActiveFalse(vp.gameObject);
    }
    //spolar fram framecount så att EndReached påkallas av playVideo()
    public void SkipVideo()
    {
        ulong frameCount = videoPlayer.clip.frameCount - 1;
        videoPlayer.frame = (long) frameCount;
    }
}
