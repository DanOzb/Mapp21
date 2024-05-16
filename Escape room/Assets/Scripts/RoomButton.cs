using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomButton : MonoBehaviour
{
    // Variable to hold the scene name assigned by RandomizeRooms script
    public string sceneName;

    // Function to load the assigned scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
