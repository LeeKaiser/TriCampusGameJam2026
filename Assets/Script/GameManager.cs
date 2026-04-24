using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    int SpawnOnLevel;
    public GameObject playerObject;
    public GameObject currentPlayer;



    public int highscore = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Enforce the singleton pattern: destroy duplicates
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //set spawn location and load game
    public void SetSpawn(int i)
    {
        SpawnOnLevel = i;
        Debug.Log($"Spawn # {i}");
        Invoke("SpawnPlayer",0.6f);
    }

    void SpawnPlayer()
    {
        GameObject[] spawnPositions = GameObject.FindGameObjectsWithTag("Respawn").OrderBy(pos => pos.name).ToArray();
        Transform spawnTransform = spawnPositions[SpawnOnLevel].transform;
        Debug.Log(spawnTransform);
        currentPlayer = Instantiate(playerObject, spawnTransform.transform.position, spawnTransform.transform.rotation);
    }

    public void EndGame()
    {
        if (highscore < currentPlayer.GetComponent<PlayerControls>().Points)
        {
            highscore = currentPlayer.GetComponent<PlayerControls>().Points;
        }
        
        Destroy(currentPlayer);

    }

    public void EndGameLoss()
    {
        Destroy(currentPlayer);
    }
}
