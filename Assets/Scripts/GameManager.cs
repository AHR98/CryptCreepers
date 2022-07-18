using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int time = 30;
    public int difficulty = 1;
    public bool isGameOver = false;
    public int score = 0;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }   
    }
    
    private void Start()
    {
        StartCoroutine(CountdownRutine());
    }
    IEnumerator CountdownRutine()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        isGameOver = true;
        UIManager.instance.showGameOverScreen();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.instance.updateUIScore(score);
            if(score % 100 == 0)
            {
                difficulty++;
            }
        }
    }

}
