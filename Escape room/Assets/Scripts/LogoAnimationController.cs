using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LogoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished; 
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("StartMenu"); 
    }
}

