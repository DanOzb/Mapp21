using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Start()
    {
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
    }

    
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
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
