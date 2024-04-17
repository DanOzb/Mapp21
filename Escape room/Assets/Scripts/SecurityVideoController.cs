
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class VideoPlayer : MonoBehaviour
{
    [SerializeField] VideoPlayer myVideoPlayer;

    void Start()
    {
        Invoke("NextScene", 9);

    }

    void NextScene()
    {
        SceneManager.LoadScene(3);
    }
}