using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    int score;
    public static GameManager inst;

    public Text scoreText;

    [SerializeField] PlayerController playerController;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE : " + score;
        // increase player's speed
        playerController.speed += playerController.speedIncreaseByPoint;
    }

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }
}
