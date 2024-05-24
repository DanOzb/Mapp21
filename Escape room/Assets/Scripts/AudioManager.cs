using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource voiceOverSource;
    public AudioSource sfxSource;

    [Range(0, 1)] public float musicVolume = 1.0f;
    [Range(0, 1)] public float voiceOverVolume = 1.0f;
    [Range(0, 1)] public float sfxVolume = 1.0f;

    private float musicTime;

    private void Awake()
    {
        if (instance == null)  
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateVolumes();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.time = musicTime;
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicTime = musicSource.time;
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.time = musicTime;
        musicSource.Play();
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        voiceOverSource.clip = clip;
        voiceOverSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayVoiceOverWithDelay(AudioClip clip, float delay)
    {
        StartCoroutine(PlayVoiceOverAfterDelay(clip, delay));
    }

    private IEnumerator PlayVoiceOverAfterDelay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayVoiceOver(clip);
    }

    public void StopAllAudio()
    {
        musicSource.Stop();
        voiceOverSource.Stop();
        sfxSource.Stop();
    }

    public void UpdateVolumes()
    {
        musicSource.volume = musicVolume;
        voiceOverSource.volume = voiceOverVolume;
        sfxSource.volume = sfxVolume;
    }


    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ToggleVoiceOver()
    {
        voiceOverSource.mute = !voiceOverSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void VoiceOverVolume(float volume)
    {
        voiceOverSource.volume = volume;
    }




}

