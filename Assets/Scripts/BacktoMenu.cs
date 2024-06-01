using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public Button menuButton; // Reference to the menu button GameObject

    void Start()
    {
        // Hide the menu button initially
        menuButton.gameObject.SetActive(false);
    }

    public void ShowMenuButton()
    {
        // Called when the player dies or completes the maze
        menuButton.gameObject.SetActive(true);
    }
}
