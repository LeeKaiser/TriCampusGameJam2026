using UnityEngine;
using UnityEngine.UI;

public class TimerKeep : MonoBehaviour
{
    Slider ScoreSlide;

    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        ScoreSlide = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentPlayer != null)
        {
            ScoreSlide.maxValue = manager.currentPlayer.GetComponent<PlayerControls>().MaxTime;
            ScoreSlide.value = manager.currentPlayer.GetComponent<PlayerControls>().RemainingTime;
        }
        
    }
}
