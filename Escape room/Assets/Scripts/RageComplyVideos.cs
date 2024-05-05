using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RageComplyVideos : MonoBehaviour
{
    public VideoPlayer videoRage;
    public VideoPlayer videoComply;
    // Start is called before the first frame update
    void Start()
    {
        Button btnComply = transform.Find("Comply").GetComponent<Button>();
        btnComply.onClick.AddListener(PlayVideoComply);

        Button btnRage = transform.Find("Rage").GetComponent<Button>();
        btnRage.onClick.AddListener(PlayVideoRage);
    }

    void PlayVideoRage()
    {
        videoRage.Play();
    }

    void PlayVideoComply()
    {
        videoComply.Play();
    }
}
