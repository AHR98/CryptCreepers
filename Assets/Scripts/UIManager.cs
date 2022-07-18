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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
}
