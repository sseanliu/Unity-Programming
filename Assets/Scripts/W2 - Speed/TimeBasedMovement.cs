using UnityEngine;
using System;
using TMPro;

public class TimeBasedMovement : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private int lastScore = 0;
    private int targetsHit = 0;

    void Start()
    {
        UpdateScoreDisplay();
    }

    void Update()
    {
        if (lastScore != TargetScript.TotalScore)
        {
            targetsHit++;
            lastScore = TargetScript.TotalScore;
            UpdateScoreDisplay();
        }
    }

    void UpdateScoreDisplay()
    {
        displayText.text = $"Score: {lastScore}";
    }
}
