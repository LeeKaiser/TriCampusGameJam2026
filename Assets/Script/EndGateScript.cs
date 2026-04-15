using UnityEngine;

public class EndGateScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
        if (player != null)
        {
            Debug.Log("Finished Game");
            
        }
    }
}
