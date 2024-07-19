using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;


    private void Awake()
    {
        // The amount of game sessions (length is how many there is):
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // The text, "livesText" will use the number that is equal to the var "playerLives"
        // Converting it to a string--so the player will be able to see how much lives they have:
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int pointstoAdd)
    {
        score += pointstoAdd;

        // This will show the amount of points the player has: 
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }

        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        // This will show the player's life (when losing a life, it will change the number):
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        // When the game resets, it will return to the menu:
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
