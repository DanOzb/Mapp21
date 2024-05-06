
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RageComplyVideos : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] GameObject questController;
    [SerializeField] GameObject container; 
    public VideoPlayer videoRage;
    public VideoPlayer videoComply;

    public void PlayVideoRage()
    {
        container.SetActive(false);
        videoRage.targetCamera = camera.GetComponent<Camera>();
        videoRage.Play();
        videoRage.loopPointReached += EndReached;
    }

    public void PlayVideoComply()
    {
        container.SetActive(false);
        videoComply.targetCamera = camera.GetComponent<Camera>();
        videoComply.Play();
        videoComply.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        Debug.Log("End reached");
        vp.gameObject.SetActive(false);
        questController.GetComponent<QuestController>().Play(1);
    }
}
