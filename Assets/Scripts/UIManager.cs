using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] Text finalScoreText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameBackground;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            showStartScreen();
        }
    }
    public void showGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScoreText.text = "SCORE: " + GameManager.instance.score;
    }
    public void updateUIScore(int _newScore)
    {
        scoreText.text = _newScore.ToString() ;
    }
    public void updateUIHealth(int _newHealth)
    {
        healthText.text = _newHealth.ToString();
    }
    public void updateUITime(int _newTime)
    {
        timeText.text = _newTime.ToString();
    }
    public void showStartScreen()
    {
        Time.timeScale = 0;
        startScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }
    public void showGameBackground()
    {
        gameBackground.SetActive(true);
        startScreen.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.startGame();
    }
}
