using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject WinOrLoseObject;
    public float remainingTime;

    private void Start()
    {
        remainingTime = 60 - QuestController.rageOrComply * 30;
    }

    void Update()
    {
        if (remainingTime < 0)
        {
            remainingTime = 0;
            if(WinOrLoseObject != null)
                WinOrLoseObject.SetActive(true);
        }
        else if (remainingTime > 0)
            remainingTime -= Time.deltaTime;

        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{00}", seconds);
    }
}
