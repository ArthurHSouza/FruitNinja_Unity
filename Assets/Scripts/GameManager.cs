using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int bestScore;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText(false);
    }
    public void UpdateScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();
        if(score > bestScore)
        {
            bestScore = score;
            UpdateBestScoreText(true);
        }    
    }
    private void UpdateBestScoreText(bool changePlayerPrefs)
    {
        if (changePlayerPrefs)
        {
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        bestScoreText.text = "Best score: " + bestScore.ToString();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
