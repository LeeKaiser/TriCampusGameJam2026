using UnityEngine;
using TMPro;

public class HighScoreNum : MonoBehaviour
{
    public string Suffix;
    TextMeshProUGUI ScoreText;

    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        ScoreText = GetComponent<TextMeshProUGUI>();
        ScoreText.text = Suffix + manager.highscore;

        
    }

    void Update()
    {
        ScoreText.text = Suffix + manager.highscore;
        if (manager.currentPlayer != null)
        {
            if (manager.currentPlayer.GetComponent<PlayerControls>().Points > manager.highscore)
            {
                ScoreText.text = Suffix + manager.currentPlayer.GetComponent<PlayerControls>().Points;
            }
        }
    }
}
