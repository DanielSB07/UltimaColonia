using System;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public int HighScore { get; private set; }

    public event Action<int> OnHighScoreChanged;

    private void Awake()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void Start()
    {
        OnHighScoreChanged?.Invoke(HighScore);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged += CheckHighScore;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= CheckHighScore;
        }
    }

    private void CheckHighScore(int currentScore)
    {
        if (currentScore > HighScore)
        {
            HighScore = currentScore;

            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            PlayerPrefs.Save();

            OnHighScoreChanged?.Invoke(HighScore);
        }
    }
}