using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int bestScore;

    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // 적 ai가 죽을때 호출
    public void ScoreUp(int n)
    {
        score += n;
        UIManager.Instance.UpdateScore(score);
    }
}
