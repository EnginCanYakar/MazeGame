using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text goldText;
    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public TMP_Text completionText;
    public GameObject blackBackground;  // Add this line

    private int playerHealth = 100;
    private int playerGold = 0;

    void Start()
    {
        if (healthText == null || goldText == null || completionText == null || blackBackground == null)
        {
            Debug.LogError("HealthText, GoldText, CompletionText, or BlackBackground is not assigned in the Inspector.");
            return;
        }

        UpdateHealthText();
        UpdateGoldText();
        gameOverScreen.SetActive(false);
        completionText.gameObject.SetActive(false);
        blackBackground.SetActive(false);  // Ensure the black background is hidden initially
    }

    public void UpdateHealth(int health)
    {
        playerHealth = health;
        UpdateHealthText();
    }

    public void AddGold(int amount)
    {
        playerGold += amount;
        UpdateGoldText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth;
    }

    private void UpdateGoldText()
    {
        goldText.text = "Gold: " + playerGold;
    }

    public void GameOver()
    {
        blackBackground.SetActive(true);  // Show the black background
        gameOverScreen.SetActive(true);
        gameOverText.text = "Try Again";
        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame method called.");
        // Unpause the game
        Time.timeScale = 1f;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishGame()
    {
        Debug.Log("Player has exited the maze. Game finished!");
        blackBackground.SetActive(true);  // Show the black background
        // Show the completion text
        completionText.gameObject.SetActive(true);
        completionText.text = "Congratulations! You escaped the maze!";
        // Pause the game or any other game completion logic
        Time.timeScale = 0f;
    }
}
