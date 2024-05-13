using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    private GameObject skipButton;
    [SerializeField] GameObject pauseMenu, pauseButton;

    public void Start()
    {
        skipButton = GameObject.FindGameObjectWithTag("Skip");
        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();

        // Pause each VideoPlayer found
        foreach (VideoPlayer player in videoPlayers)
        {
            player.Pause();
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();

        // Pause each VideoPlayer found
        foreach (VideoPlayer player in videoPlayers)
        {
            player.Pause();
        }
        if(skipButton != null)
            skipButton.SetActive(false);
        pauseButton.SetActive(false);
    }

    
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        if (skipButton != null)
            skipButton.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1;

        // Find all VideoPlayer components in the scene
        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();

        // Resume each VideoPlayer found
        foreach (VideoPlayer player in videoPlayers)
        {
            player.Play();
        }
    }
}
