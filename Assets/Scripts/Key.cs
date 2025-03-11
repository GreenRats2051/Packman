using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSourcePickUp;
    [SerializeField] protected GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            audioSourcePickUp.Play();
            gameManager.keys++;
            gameManager.UpdateKeyImages();
            gameObject.SetActive(false);
        }
    }
}