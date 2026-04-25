using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction DriftAction;
    
    public float acceleration = 0.25f;
    public float DriftExtraRotation;
    public float DriftDecreaseRotation;
    public float DriftSpeedBoost;
    public float BoostAngle;

    public int mapSize;

    public int Points;

    public float SpawnTileDistance = 30;

    public float RemainingTime = 30;
    public float MaxTime = 30;

    public ParticleSystem driftEffect;

    [Header("debug")]
    [SerializeField] int endOfGameScene;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [SerializeField] float forwardSpeedCap;
    [SerializeField] float extraRotation;
    [SerializeField] Vector3 movementDirection;


    [SerializeField] bool isDrifting = false;

    
    [SerializeField] float facingDirectionDifference;
    [SerializeField] LayerMask spawnTileMask;

    [SerializeField] AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
        DriftAction.Enable();
        Application.targetFrameRate = 60;
        movementDirection = transform.up;
        audioSource = GetComponent<AudioSource>();
        driftEffect.Pause();
        audioSource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        
        MoveAndRotate(move.y, -move.x);
        
        if (DriftAction.IsPressed())
        {
            isDrifting = true;
            driftEffect.Play();
            audioSource.UnPause();
        }
        else
        {
            isDrifting = false;
            driftEffect.Pause();
            audioSource.Pause();
        }
        if (facingDirectionDifference > BoostAngle || facingDirectionDifference < -BoostAngle){
            forwardSpeedCap += Time.deltaTime * DriftSpeedBoost;
        }

        WrapAroundMap();

        RemainingTime -= Time.deltaTime;
        if (RemainingTime >= MaxTime)
        {
            RemainingTime = MaxTime; 
        }
        if (RemainingTime <= 0)
        {
            FindAnyObjectByType<GameManager>().EndGameLoss();
            FindAnyObjectByType<SceneLoader>().LoadNextScene(endOfGameScene);
        }

    }

    void FixedUpdate()
    {
        // //spawn items on nearby tiles
        // Collider2D[] hits = OverlapCircle(transform.position, SpawnTileDistance, spawnTileMask);

        // foreach (Collider2D tiles in hits)
        // {
        //     ItemSpawnerTile spawnTile = tiles.gameObject.GetComponent<ItemSpawnerTile>();
        //     spawnTile.SpawnNewItem();
        // }
    }

    public void WrapAroundMap()
    {
        if (Mathf.Abs(transform.position.x) > mapSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(transform.position.y) > mapSize)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
        }

    }

    public void MoveAndRotate(float movementIn, float rotationIn)
    {
        //determine angle to rotate
        float rotationAngle = rotationIn  * (rotationSpeed + (2*speed)) * Time.deltaTime;
        float directionRot = rotationAngle;

        //if drifting, rotation angle rotates more while directionRot rotates less. if not drifting after drifting, the difference is made up
        if (isDrifting)
        {
            rotationAngle += rotationIn* DriftExtraRotation * Time.deltaTime;
            directionRot -= rotationIn * DriftDecreaseRotation * Time.deltaTime;
            facingDirectionDifference += (DriftExtraRotation + DriftDecreaseRotation) * Time.deltaTime * rotationIn;
        }
        else
        {
            directionRot += facingDirectionDifference;
            facingDirectionDifference = 0;
        }
        //change movement direction
        movementDirection = new Vector3(
            movementDirection.x * Mathf.Cos(directionRot* Mathf.Deg2Rad) - movementDirection.y * Mathf.Sin(directionRot* Mathf.Deg2Rad), 
            movementDirection.x * Mathf.Sin(directionRot* Mathf.Deg2Rad) + movementDirection.y * Mathf.Cos(directionRot* Mathf.Deg2Rad), 0);

        //change character speed & rotate model
        transform.Rotate(new Vector3(0,0,rotationAngle));

        speed += movementIn * acceleration * Time.deltaTime;
        if (speed > forwardSpeedCap )
        {
            speed = forwardSpeedCap;
        }

        //move character by the direction and speed
        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

    }

    public void GivePoints(int pointGain)
    {
        Points += pointGain;
    }
}
