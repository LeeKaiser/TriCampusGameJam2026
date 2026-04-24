using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public int PointValue = 1;
    public float TimeGiven = 0.05f;
    public GameObject collectParticle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
        if (player != null)
        {
            Debug.Log("Collected point");
            player.GivePoints(PointValue);
            player.RemainingTime += TimeGiven;
            GameObject Effect = Instantiate(collectParticle, transform.position, transform.rotation);
            Destroy(Effect, 1);
            Destroy(gameObject);
        }
    }
}
