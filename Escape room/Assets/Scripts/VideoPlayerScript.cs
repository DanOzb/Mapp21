using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

//F�r att f� scriptet att fungera, byt inte namn p� spel objekten
//som h�ller videoplayers och video klipp.
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
        //s�tter r�tt rum till room
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
        //spelar den f�rsta videon fr�n room
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

    //p�kallas av playvideo n�r videon har n�tt slutet
    void EndReached( VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        playVideo();
    }

    //tar emot en videoplayer, spelar den och kallar n�sta object fr�n QuestController
    public void PlayExtraVideos(VideoPlayer vp)
    {
        videoPlayer = vp;
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += SetActiveFalse;
        this.gameObject.transform.GetChild(0).GetComponent<QuestController>().Play(1);
    }
    //s�tter objektet till false
    public void SetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
    }
    //s�tter videoplayer objektet till false
    public void SetActiveFalse(VideoPlayer vp)
    {
        SetActiveFalse(vp.gameObject);
    }
    //spolar fram framecount s� att EndReached p�kallas av playVideo()
    public void SkipVideo()
    {
        ulong frameCount = videoPlayer.clip.frameCount - 1;
        videoPlayer.frame = (long) frameCount;
    }
}
