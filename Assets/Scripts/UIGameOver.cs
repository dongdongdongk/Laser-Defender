using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
    }

    void Start()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper not found in the scene!");
        }
        if (scoreKeeper != null)
        {
            scoreText.text = "You Scored:\n " + scoreKeeper.GetScore();
        }
        else
        {
            scoreText.text = "You Scored:\n N/A";
            Debug.LogError("Cannot display score: ScoreKeeper is null.");
        }
    }
}
