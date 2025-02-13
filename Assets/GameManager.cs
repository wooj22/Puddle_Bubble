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

    private void Start()
    {
        SoundManager.Instance.FadeInBGM();
    }

    // 적 ai가 죽을때 호출 (기획자분이 계산하고싶은 점수 방식이 따로 잇다해서 일단 이거 안씀)
    public void ScoreUp(int n)
    {
        score += n;
        UIManager.Instance.UpdateScore(score);
    }
}
