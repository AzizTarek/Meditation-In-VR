using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void PlayNature()
    {
        SceneManager.LoadScene("Forest"); // Load the natural scene
    }
    public void PlaySpace()
    {
        SceneManager.LoadScene("Space"); // Load the space scene
    }
    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
