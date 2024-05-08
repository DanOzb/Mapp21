using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipVideoButton : MonoBehaviour
{
    public VideoPlayer[] videoPlayers; // Array of VideoPlayers
    public OpenQuestContainer questContainerOpener;// Reference to the script that opens the QuestContainer
    private int currentVideoIndex = 0; // Index of the currently playing video
    

    public void SkipVideo()
    {
        // Stop the current VideoPlayer
        if (currentVideoIndex < videoPlayers.Length)
        {
            videoPlayers[currentVideoIndex].Stop();
            currentVideoIndex++;

            // Check if there are more videos to play
            if (currentVideoIndex < videoPlayers.Length)
            {
                // Play the next VideoPlayer
                videoPlayers[currentVideoIndex].Play();
            }
            else
            {
                // If this is the last video, open the QuestContainer
                questContainerOpener.OpenContainer();
            }
        }
    }
}
