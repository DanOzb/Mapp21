using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomizeRooms : MonoBehaviour
{
    // Array to hold the names of your room scenes
    public string[] roomScenes;

    void Start()
    {
        // Shuffle the array of room scenes
        ShuffleArray(roomScenes);

        // Loop through the buttons and assign a random scene to each one
        for (int i = 0; i < roomScenes.Length; i++)
        {
            // Assuming you have buttons named "Room1Button", "Room2Button", etc.
            GameObject button = GameObject.Find("Room" + (i + 1) + "Button");
            if (button != null)
            {
                button.GetComponent<RoomButton>().sceneName = roomScenes[i];
            }
        }
    }

    // Function to shuffle the array
    void ShuffleArray(string[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}