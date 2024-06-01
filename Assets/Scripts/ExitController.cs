using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in ExitController.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.FinishGame();
        }
    }
}

