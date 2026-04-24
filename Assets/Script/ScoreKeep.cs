using UnityEngine;
using TMPro;

public class ScoreKeep : MonoBehaviour
{
    public string Suffix;
    TextMeshProUGUI ScoreText;

    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentPlayer != null)
        {
            ScoreText.text = Suffix + manager.currentPlayer.GetComponent<PlayerControls>().Points;
        }
        
    }
}
