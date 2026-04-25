using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public int PointValue = 1;
    public float TimeGiven = 0.05f;
    public GameObject collectParticle;
    public AudioClip collectSound;

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
            Effect.GetComponent<AudioSource>().PlayOneShot(collectSound, 0.4F);
            Destroy(Effect, 1);
            Destroy(gameObject);
        }
    }
}
