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

    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        camera = GameObject.Find("Main Camera");
        foreach (GameObject rm in rooms)
        {
            if (rm.name.Contains((roomNumber + 1).ToString()))
                room = rm;
        }
        print(room.name);
        playVideo();
    }

    void playVideo()
    {
        videoPlayer = room.GetComponentInChildren<VideoPlayer>();
        if (videoPlayer == null)
            SceneManager.LoadScene(3);
        else
        {
            videoPlayer.targetCamera = camera.GetComponent<Camera>();
            videoPlayer.Play();
            videoPlayer.loopPointReached += EndReached;
        }
    }

    void EndReached( VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        playVideo();
    }

}
