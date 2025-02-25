using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float animationTime;
    [SerializeField] private bool loop;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int animationFrame;

    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    private void Advance()
    {
        animationFrame++;

        if (animationFrame >= sprites.Length && loop)
        {
            animationFrame = 0;
        }

        if (animationFrame >= 0 && animationFrame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[animationFrame] ?? null;
        }
    }

    public void Restart()
    {
        animationFrame = -1;

        Advance();
    }
}