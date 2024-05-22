using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    private float desiredAlpha = 0f;
    private float time = 1f;
    [SerializeField] Image background;
    [SerializeField] Button play;
    [SerializeField] Button settings;
    [SerializeField] TextMeshProUGUI playText;
    [SerializeField] TextMeshProUGUI settingsText;
    [SerializeField] GameObject settingsPanel;

    public void StartGame()
    {
        RoomController.roomNumbers = 0;
        Invoke("FadeOut", 0.2f);
        Invoke("LoadGame", time + 0.3f);
    }

    private void FadeOut()
    {
        background.CrossFadeAlpha(desiredAlpha, time+1, false);
        play.image.CrossFadeAlpha(desiredAlpha, time, false);
        playText.CrossFadeAlpha(desiredAlpha, time, false);
        settings.image.CrossFadeAlpha(desiredAlpha, time, false);
        settingsText.CrossFadeAlpha(desiredAlpha, time, false);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnButtonClick(Button button)
    {
        if(button == play)
        {
            play.interactable = false;
            settings.interactable = false;
        }
    }

}
