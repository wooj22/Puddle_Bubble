using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 알맞게 추가해서 사용하기
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    [SerializeField] private GameObject overUI;
    [SerializeField] private Text overScore;
    [SerializeField] private Text overBestScore;

    [SerializeField] private Image FadeIamge;

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

    public void GameOverUI()
    {
        overUI.SetActive(true);
        overScore.text = scoreText.text;
        overBestScore.text = bestScoreText.text;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCo());
    }

    IEnumerator FadeInCo()
    {
        float fadeCount = 1;

        while (fadeCount > 0.001f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            FadeIamge.color = new Color(0, 0, 0, fadeCount);
        }
    }
}