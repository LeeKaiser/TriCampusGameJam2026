using UnityEngine;
using UnityEngine.UI;

public class EnterLevelButtons : MonoBehaviour
{

    GameManager manager;

    void Update()
    {
        if (manager == null)
        {
            manager = FindAnyObjectByType<GameManager>();
        }
    }

    public void EnterLevel(int i)
    {
        manager.SetSpawn(i);
    }
}
