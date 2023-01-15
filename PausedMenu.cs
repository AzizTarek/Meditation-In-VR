using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //boolean variable that indicates if the game is paused
    public GameObject pausedMenuUI; // Pause menu panel
    
    // Update is called once per frame
    void Update()
    {      
        if ( Input.GetKeyDown(KeyCode.Escape))  // if escape is pressed then pause or resume
        {
            if(GameIsPaused)
                Resume();
            else
                Pause();            
        }
    }

    public void Resume()
    {
        pausedMenuUI.SetActive(false); // disable pause menu panel
        Time.timeScale = 1f;//UnFreeze the game
        GameIsPaused = false; //change value of a boolean variable
    }

    public  void Pause()
    {
        pausedMenuUI.SetActive(true); // enable pause menu panel
        Time.timeScale = 0f;//Freeze the game
        GameIsPaused = true; //change value of a boolean variable

        SettingsMenu setMenu = gameObject.GetComponent<SettingsMenu>();

        if(setMenu!=null) 
          setMenu.paused = true; // update the boolean value of a class as it is needed to serve a function in that class
    }

    public void LoadMenu() //go to home page
    {
        Time.timeScale = 1f;//UnFreeze the game in case its frozen
        SceneManager.LoadScene("MainMenu"); // the scene that has the home page loads
    }

    public void Restart() // Restart the current scene
    {
        Time.timeScale = 1f;//UnFreeze the game in case its frozen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the scene
    }

}
