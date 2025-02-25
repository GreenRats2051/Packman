using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField] protected GameManager gameManager;
    public int points;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    protected virtual void Eat()
    {
        gameManager.PelletEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}