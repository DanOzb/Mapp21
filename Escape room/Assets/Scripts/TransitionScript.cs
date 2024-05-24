using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TransitionScript : MonoBehaviour
{
    public static bool nextTransition;
    public static int sceneToLoad;
    private bool transitioning = false;

    [SerializeField] Animator transition;
    public float transitionTime = 2f;

    private void Update()
    {
        if (nextTransition && !transitioning)
        {
            transitioning = true;
            LoadScene(sceneToLoad);
        }

    }

    public void LoadScene(int index)
    {
        sceneToLoad = index;
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        nextTransition = false;
        SceneManager.LoadScene(sceneToLoad);
    }
}

