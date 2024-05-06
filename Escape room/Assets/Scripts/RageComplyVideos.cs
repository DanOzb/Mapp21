
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RageComplyVideos : MonoBehaviour
{
    public VideoPlayer videoRage;
    public VideoPlayer videoComply;
    
   

    public void PlayVideoRage()
    {
        videoRage.Play();
    }

    public void PlayVideoComply()
    {
        videoComply.Play();
    }
}
