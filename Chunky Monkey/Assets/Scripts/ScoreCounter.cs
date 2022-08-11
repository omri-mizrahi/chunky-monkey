using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    #region Variables
    public static ScoreCounter Instance;
    int score;
    TextMeshProUGUI scoreText;
    #endregion

    void Awake()
    {
        Instance = this;
        score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScore(5);
    }

    void Update()
    {
        
    }

    public void UpdateScore(int scoreInc) {
        score += scoreInc;
        scoreText.SetText(score.ToString());
    }
}
