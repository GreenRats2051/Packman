using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ghost[] ghosts;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;
    [SerializeField] private GameObject gameState;
    [SerializeField] private Text gameStateText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image[] lifeImages;
    [SerializeField] private Color lifeSprite;
    [SerializeField] private Color emptyLifeSprite;
    [SerializeField] private Image[] keyImages;
    [SerializeField] private Color keySprite;
    [SerializeField] private Color emptyKeySprite;

    public int score { get; set; }
    public int lives { get; set; }
    public int keys { get; set; }

    private int ghostMultiplier;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0)
        {
            gameStateText.color = Color.red;
            gameStateText.text = "Game Over";
            gameState.SetActive(true);
        }

        if (!HasRemainingPellets() && keys == 3)
        {
            gameStateText.color = Color.green;
            gameStateText.text = "Game Win";
            gameState.SetActive(true);
        }
    }

    public void NewGame()
    {
        SetScore(0);
        SetLives(3);
        SetKeys(0);
        NewRound();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void NewRound()
    {
        gameState.SetActive(false);

        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        gameState.SetActive(true);

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        UpdateLifeImages();
    }

    private void UpdateLifeImages()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < lives)
            {
                lifeImages[i].color = lifeSprite;
            }
            else
            {
                lifeImages[i].color = emptyLifeSprite;
            }
        }
    }

    private void SetKeys(int key)
    {
        this.keys = key;
        UpdateKeyImages();
    }

    public void UpdateKeyImages()
    {
        for (int i = 0; i < keyImages.Length; i++)
        {
            if (i < keys)
            {
                keyImages[i].color = keySprite;
            }
            else
            {
                keyImages[i].color = emptyKeySprite;
            }
        }
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();

        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }
}