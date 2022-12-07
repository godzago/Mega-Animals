using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int Puan;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void ScorManager()
    {
        Puan += 5;
        scoreText.text = Puan.ToString();
    }
}
