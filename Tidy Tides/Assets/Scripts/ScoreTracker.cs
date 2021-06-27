using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public int score = 0;
    private TextMeshProUGUI scoreText;
    #region Singleton
    public static ScoreTracker instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ScoreTracker found");
            return;
        }
        instance = this;
    }
    #endregion

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
    }
}
