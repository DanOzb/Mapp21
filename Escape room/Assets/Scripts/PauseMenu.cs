using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, skipButton, pauseButton;
    public static bool _pause = false;

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        _pause = true;
    }

    public void ResumeGame()
    {
        _pause = false;
    }

}
