using UnityEngine;

public class EndGateScript : MonoBehaviour
{
    SceneLoader sceneLoad;
    GameManager manager;
    public int endGameScene;
    void Start()
    {
        sceneLoad = (SceneLoader)FindAnyObjectByType(typeof(SceneLoader));
        manager = (GameManager)FindAnyObjectByType(typeof(GameManager));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
        if (player != null)
        {
            Debug.Log("Finished Game");
            manager.EndGame();
            sceneLoad.LoadNextScene(endGameScene);
            
        }
    }
}
