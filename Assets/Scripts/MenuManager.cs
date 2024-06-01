using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene when the "Play Game" button is clicked
        SceneManager.LoadScene("secondsceene");
    }

    public void QuitGame()
    {
        // Quit the game when the "Quit Game" button is clicked
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}


