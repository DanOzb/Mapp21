using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float remainingTime;

    private void Start()
    {
        remainingTime = 60 - QuestController.rageOrComply * 30;
    }

    void Update()
    {
        if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        else if (remainingTime > 0)
            remainingTime -= Time.deltaTime;

        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{00}", seconds);
    }
}
