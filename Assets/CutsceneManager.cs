using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutsceneManager : MonoBehaviour
{
    public Animator characterAnimator; // Reference to the character's Animator
    public GameObject character; // Reference to the character GameObject
    public float cutsceneDuration = 15.0f; // Duration of the cutscene

    private PlayerMovement playerMovement; // Reference to the character's movement script

    void Start()
    {
        // Assume the cutscene starts automatically, otherwise, call StartCutscene() when appropriate
        StartCutscene();
    }

    void StartCutscene()
    {
        // Find the CharacterMovement script on the character
        playerMovement = character.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Disable the movement script
        }

        // Optionally, start the cutscene animation or other cutscene-related logic here
        Invoke("EndCutscene", cutsceneDuration);
    }

    void EndCutscene()
    {
        // Play the "Laying down" animation
        characterAnimator.Play("Player_LayDown");

        // Ensure the character remains immobile
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }
}