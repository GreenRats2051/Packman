using UnityEngine;

public class PowerPellet : Pellet
{
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