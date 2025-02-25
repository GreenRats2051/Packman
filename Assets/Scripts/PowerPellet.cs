using UnityEngine;

public class PowerPellet : Pellet
{
    [SerializeField] private GameManager gameManager;

    public float duration;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    protected override void Eat()
    {
        gameManager.PowerPelletEaten(this);
    }
}