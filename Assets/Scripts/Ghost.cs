using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement { get; set; }
    public GhostHome home { get; set; }
    public GhostScatter scatter { get; set; }
    public GhostChase chase { get; set; }
    public GhostFrightened frightened { get; set; }
    public GhostBehavior initialBehavior;
    public Transform target;
    public int points { get; set; }

    private GameManager gameManager;

    private void Start()
    {
        movement = GetComponent<Movement>();
        home = GetComponent<GhostHome>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
        gameManager = FindAnyObjectByType<GameManager>();

        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);

        if (movement != null)
        {
            movement.ResetState();
        }

        if (frightened != null)
        {
            frightened.Disable();
        }

        if (chase != null)
        {
            chase.Disable();
        }

        if (scatter != null)
        {
            scatter.Enable();
        }

        if (home != null && home != initialBehavior)
        {
            home.Disable();
        }

        if (initialBehavior != null)
        {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                gameManager.GhostEaten(this);
            }
            else
            {
                gameManager.PacmanEaten();
            }
        }
    }
}