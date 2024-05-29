using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class MasterVolumeController : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Button muteButton; 
    [SerializeField] private Sprite unmutedSprite; 
    [SerializeField] private Sprite mutedSprite; 

    private List<AudioSource> allAudioSources = new List<AudioSource>();
    private List<VideoPlayer> allVideoPlayers = new List<VideoPlayer>();
    private bool isMuted = false;
    private float previousVolume = 1.0f; // Store the previous volume before muting

    private void Start()
    {
        //hitta alla audioSources
        allAudioSources.AddRange(FindObjectsOfType<AudioSource>());

        
        allVideoPlayers.AddRange(FindObjectsOfType<VideoPlayer>());

        // kolla om det finns en setting, annars lägg volymen på 1.0
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            previousVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("MasterVolume", 1.0f);
            PlayerPrefs.Save();
            previousVolume = 1.0f; // sätt standard volym till 1.0
        }

        // Add a listener to the slider to call the OnVolumeChange method when the value changes
        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.value = previousVolume; // Set slider value to the saved volume
            masterVolumeSlider.onValueChanged.AddListener(OnVolumeChange);
            // Set initial volume based on slider value
            OnVolumeChange(masterVolumeSlider.value);
        }

        // Add a listener to the mute button to call the ToggleMute method when clicked
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
            UpdateMuteButtonSprite(); // Set the initial sprite for the mute button
        }
    }

    private void OnVolumeChange(float volume)
    {
        if (!isMuted) // Only change volume if not muted
        {
            foreach (var audioSource in allAudioSources)
            {
                audioSource.volume = volume;
            }

            foreach (var videoPlayer in allVideoPlayers)
            {
                videoPlayer.SetDirectAudioVolume(0, volume);
            }
        }
        previousVolume = volume; // Store the current volume
        PlayerPrefs.SetFloat("MasterVolume", volume); // Save the volume to PlayerPrefs
        PlayerPrefs.Save();
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // Mute all audio sources and video players
            foreach (var audioSource in allAudioSources)
            {
                audioSource.volume = 0;
            }

            foreach (var videoPlayer in allVideoPlayers)
            {
                videoPlayer.SetDirectAudioVolume(0, 0);
            }
        }
        else
        {
            // Restore the previous volume
            foreach (var audioSource in allAudioSources)
            {
                audioSource.volume = previousVolume;
            }

            foreach (var videoPlayer in allVideoPlayers)
            {
                videoPlayer.SetDirectAudioVolume(0, previousVolume);
            }
        }

        UpdateMuteButtonSprite(); // Update the mute button sprite
    }

    private void UpdateMuteButtonSprite()
    {
        if (muteButton != null)
        {
            Image buttonImage = muteButton.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = isMuted ? mutedSprite : unmutedSprite;
            }
        }
    }

    // Call this method if you dynamically add new audio sources or video players
    public void UpdateAudioAndVideoSources()
    {
        allAudioSources.Clear();
        allAudioSources.AddRange(FindObjectsOfType<AudioSource>());

        allVideoPlayers.Clear();
        allVideoPlayers.AddRange(FindObjectsOfType<VideoPlayer>());
    }
}




