﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    // Make public variables to store the UI elements for the main menu.
    public Button startButton;
    public Button quitButton;

    // This delay allows the screen to fade out before changing levels.
    public float transitionDelay = 2f;

    void Start()
    {
        // Add listeners to make buttons functional.
        startButton.onClick.AddListener(EnableTransition);

        quitButton.onClick.AddListener(QuitGame);
    } // Start

    void EnableTransition()
    {
        // Fade the screen out with this panel...
        // transitionPanel.SetActive(true);

        // ...and load the next scene in x seconds.
        Invoke("LoadShipyard", transitionDelay);
    } // EnableTransition

    void LoadShipyard()
    {
        // Load "Setup" scene.
        SceneManager.LoadScene("Shipyard");
    } // LoadSetup

    void QuitGame()
    {
        Application.Quit();
    } // QuiteGame
}
