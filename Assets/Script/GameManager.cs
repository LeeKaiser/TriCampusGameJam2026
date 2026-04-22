using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    int SpawnOnLevel;
    public GameObject playerObject;
    GameObject currentPlayer;

    int highscore = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //set spawn location and load game
    public void SetSpawn(int i)
    {
        SpawnOnLevel = i;
        Invoke("SpawnPlayer",0.6f);
    }

    void SpawnPlayer()
    {
        GameObject[] spawnPositions = GameObject.FindGameObjectsWithTag("Respawn").OrderBy(pos => pos.name).ToArray();
        Transform spawnTransform = spawnPositions[SpawnOnLevel].transform;
        Debug.Log(spawnTransform);
        currentPlayer = Instantiate(playerObject, spawnTransform.transform.position, spawnTransform.transform.rotation);
    }
}
