using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in PlayerHealth.");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        gameManager.UpdateHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Player Died");
        gameManager.GameOver();
        // Disable player controls or any other logic you need on death
    }
}

