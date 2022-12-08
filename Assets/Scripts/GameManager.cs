using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Puan;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        scoreText.text = Puan.ToString();
    }
    public void ScorManager()
    {
        Puan += 5;
        scoreText.text = Puan.ToString();

        if (Puan > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Puan);
            HighScoreText.text = Puan.ToString();
        }
    }
}
