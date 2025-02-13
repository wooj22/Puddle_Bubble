using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 알맞게 추가해서 사용하기
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = "BestScore : " + bestScore.ToString();
    }
}