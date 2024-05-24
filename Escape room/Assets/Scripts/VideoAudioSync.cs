using UnityEngine;
using UnityEngine.Video;

public class VideoAudioSync : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private void Start()
    {
        // Ensure the AudioSource is not playing at the start
        audioSource.Stop();

        // Register for the video player's prepare completed event
        videoPlayer.prepareCompleted += OnPrepareCompleted;
        videoPlayer.loopPointReached += OnVideoEnd;

        // Optionally, you can prepare the video ahead of time
        videoPlayer.Prepare();
    }

    private void OnPrepareCompleted(VideoPlayer vp)
    {
        // Start the video and audio together
        videoPlayer.Play();
        audioSource.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Stop the audio when the video ends
        audioSource.Stop();
    }
}
