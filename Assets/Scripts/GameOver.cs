using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    private GameManager gameManager;
    private int score;

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = gameManager.Score;
        scoreText.text = score.ToString();
    }
}
