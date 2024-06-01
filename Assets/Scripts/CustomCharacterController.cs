using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 2f; // Character's movement speed

    public GameObject characterUpPrefab; // Prefab for character facing up
    public GameObject characterDownPrefab; // Prefab for character facing down
    public GameObject characterSidePrefab; // Prefab for character facing left/right

    private GameObject characterUp; // Instance of character facing up
    private GameObject characterDown; // Instance of character facing down
    private GameObject characterSide; // Instance of character facing left/right

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 defaultScale = new Vector3(0.3124878f, 0.3263756f, 1f); // Default scale for all directions

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InstantiateCharacterPrefabs();
        DisableAllCharacterDirections();
        characterDown.SetActive(true); // Set initial direction
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Update character direction based on movement direction
        if (movement.x > 0) // Right
        {
            DisableAllCharacterDirections();
            characterSide.SetActive(true);
            characterSide.transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z); // Ensure the character faces right
        }
        else if (movement.x < 0) // Left
        {
            DisableAllCharacterDirections();
            characterSide.SetActive(true);
            characterSide.transform.localScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z); // Flip the character to face left
        }
        else if (movement.y > 0) // Up
        {
            DisableAllCharacterDirections();
            characterUp.SetActive(true);
            characterUp.transform.localScale = defaultScale; // Ensure correct scale
        }
        else if (movement.y < 0) // Down
        {
            DisableAllCharacterDirections();
            characterDown.SetActive(true);
            characterDown.transform.localScale = defaultScale; // Ensure correct scale
        }
    }

    void FixedUpdate()
    {
        // Move the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void InstantiateCharacterPrefabs()
    {
        // Instantiate character prefabs from the assets
        characterUp = Instantiate(characterUpPrefab, transform.position, Quaternion.identity);
        characterDown = Instantiate(characterDownPrefab, transform.position, Quaternion.identity);
        characterSide = Instantiate(characterSidePrefab, transform.position, Quaternion.identity);

        // Set parent to ensure correct position relative to the main character GameObject
        characterUp.transform.SetParent(transform);
        characterDown.transform.SetParent(transform);
        characterSide.transform.SetParent(transform);

        // Disable all character GameObjects initially
        DisableAllCharacterDirections();
    }

    void DisableAllCharacterDirections()
    {
        characterUp.SetActive(false);
        characterDown.SetActive(false);
        characterSide.SetActive(false);
    }
}
