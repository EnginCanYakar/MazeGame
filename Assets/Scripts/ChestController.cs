using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerNearby = false;
    public GameManager gameManager; // Ensure this is assigned in the Inspector
    public int goldAmount = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in ChestController.");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChestTrigger");

        if (gameManager != null)
        {
            gameManager.AddGold(goldAmount);
        }
        else
        {
            Debug.LogError("GameManager is not assigned in ChestController.");
        }

        Destroy(gameObject, 1f); // Destroy chest after 1 second to allow animation to play
    }
}

