using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private HighScoreManager highScoreManager;

    private void Start()
    {
        if (highScoreManager == null)
        {
            Debug.LogError("Asigna HighScoreManager en el Inspector.");
            return;
        }

        UpdateHighScore(highScoreManager.HighScore);
        highScoreManager.OnHighScoreChanged += UpdateHighScore;
    }

    private void OnDestroy()
    {
        if (highScoreManager != null)
        {
            highScoreManager.OnHighScoreChanged -= UpdateHighScore;
        }
    }

    private void UpdateHighScore(int newHighScore)
    {
        if (highScoreText != null)
        {
            highScoreText.text = "Récord: " + newHighScore;
        }
    }
}