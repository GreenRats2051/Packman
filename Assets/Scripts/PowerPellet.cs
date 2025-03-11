using UnityEngine;

public class PowerPellet : Pellet
{
    public int duration;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    protected override void Eat()
    {
        gameManager.PowerPelletEaten(this);
    }
}