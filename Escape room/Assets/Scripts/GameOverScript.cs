using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("pressed");
        RoomController.roomNumbers = 0;
        TransitionScript.sceneToLoad = 1;
        TransitionScript.nextTransition = true;
    }

    public void GoToHomeScreen()
    {
        TransitionScript.sceneToLoad = 0;
        TransitionScript.nextTransition = true;
    }

}
