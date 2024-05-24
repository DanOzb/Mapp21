using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider, _voiceSlider;

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSfx();
    }

    public void ToggleVoiceOver()
    {
        AudioManager.instance.ToggleVoiceOver();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SfxVolume()
    {
        AudioManager.instance.SfxVolume(_sfxSlider.value);
    }

    public void VoiceOverVolume()
    {
        AudioManager.instance.VoiceOverVolume(_voiceSlider.value);
    }
}
