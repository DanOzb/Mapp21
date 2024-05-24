using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondQuest : MonoBehaviour
{

    public Text questionText;
    public Text[] answerTexts;
    public GameObject gameOverPanel;

    
    private string[] questions = { "Fråga 1: Vilken anime handlar om en ung ninja vars dröm är att bli den starkaste i sitt bysamhälle?", "Fråga 2: Vilken anime handlar om en grupp tonåringar som använder övernaturliga krafter för att bekämpa monster och skydda mänskligheten?", "Fråga 3: Vilken anime är känd för sina enorma robotar, dramatiska strider och psykologiska teman?" };
    private string[][] answers = {
        new string[] { " A) One Piece", "B) Naruto", "C) Dragon Ball Z", "D) Attack on Titan" },
        new string[] { "A) Bleach", "B) My Hero Academia", "C) Tokyo Ghoul", "D) Evangelion" },
        new string[] { "A) Gundam Wing", "B) Cowboy Bebop", "C) Fullmetal Alchemist", "D) Neon Genesis Evangelion" }
    };
    
    private int[] correctAnswers = { 1, 3, 3 };

    private int currentQuestionIndex;
    private object deathMessageText;



    // Start is called before the first frame update
    private void Start()
    {
        
     
        

        gameOverPanel.SetActive(false);
        ShowRandomQuestion();
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Rätt Svar, du överlever!");
            TransitionScript.sceneToLoad = 2;
            TransitionScript.nextTransition = true;
        }
        else
        {
            Debug.Log("Fel svar, du är död!");
            gameOverPanel.SetActive(true);
        }
    }

    private void ShowRandomQuestion()
    {
        currentQuestionIndex = Random.Range(0, questions.Length);

        questionText.text = questions[currentQuestionIndex];
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = answers[currentQuestionIndex][i];
        }
    }

}
