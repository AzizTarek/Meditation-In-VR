using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; 
  
    public GameObject windy, rainy, day, night; // gameobjects with radio buttons attached to them
    public Light myLight; // directional light
    public GameObject windZone; // windzone
    public GameObject rain; // rain particles
    public AudioSource meditation_guide; // audio for the meditation guide

    //Timelines that have multiple audio ffiles
    public PlayableDirector boxBreath_timeline;
    public PlayableDirector lionsBreath_timeline;
    public PlayableDirector _478Breath_timeline;

    public GameObject moodCanvas; // Panel that hold information about the user's mood
    public GameObject menuCanvas; // Main menu panel with a set of buttons
    public GameObject appGuideCanvas; // Panel of information about the app
    public TextMeshProUGUI moodText;
    private float old_moodValue; // Value of the user's mood before changing to allow a comparison of their mood
    
    //skyboxes
    public Material skybox_night;
    public Material skybox_day;

    public bool paused = false; // indicates app is paused
    private bool first_time = true; // Boolean to check if it is the first the user entered the scene

    public bool breathing_technique_used = false; // Boolean to Check if the user has played any of the breathing techniques timelines

    public void Start()
    {
        old_moodValue = GlobalControl.Instance.moodValue; //Getting mood value from a globally acessible class
       
    }
    public void Update()
    {
        //toggle group of day and night
        if (day.GetComponent<Toggle>().isOn) //day
        {
            myLight.intensity = 3; // set directional light to 3 
            RenderSettings.skybox = skybox_day; // change skybox
        }
        else if (night.GetComponent<Toggle>().isOn) //night
        {
            myLight.intensity = 0;// set directional light to 0 to disable its effect
            RenderSettings.skybox = skybox_night; // change skybox
        }



        //windy toggle
        if (windy.GetComponent<Toggle>().isOn)
            windZone.SetActive(true); // enable windzone
        else
            windZone.SetActive(false); // disable windzone

        //Rainy toggle
        if (rainy.GetComponent<Toggle>().isOn)
           rain.SetActive(true); // enable particle system
        else
           rain.SetActive(false); // disable particle system

        if (boxBreath_timeline.state != PlayState.Playing && lionsBreath_timeline.state != PlayState.Playing && _478Breath_timeline.state != PlayState.Playing)
            // if none of the timelines are playing then resume guided meditation
        {
            if(!paused)
             meditation_guide.UnPause(); // resume
        }

        if(breathing_technique_used)
            moodUpdate_Canvas(); // if breathing technique has been used then ask the user what their curent mood is like


        

    }
    public void ChangeBreathingTechniqueBoolValue() // Changes the breathing technique value , this method is used for a click event
    {
        if (breathing_technique_used)
            breathing_technique_used = false;
        else
            breathing_technique_used = true;
    }
     
    public void SetVolume(float volume) // Dynamically changes the main volume
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void appGuideInitiateInstructorAudio()
        // Checks if the user entered the environment for the first time
        // and if the information display has been closed to initiate the guide
    {
        if (!appGuideCanvas.activeSelf && first_time)
        {
            meditation_guide.Play();
            first_time = false;
        }
      
    }


    public void SetBgMusicVolume(float volume) // Dynamically changes the background music volume
    {
        audioMixer.SetFloat("Background Music", volume);
    }

    public void SetSfxVolume(float volume) // Dynamically changes the sound effects volume
    {
        audioMixer.SetFloat("Sound Effects", volume);
    }

    public void SetInstructorVoiceVolume(float volume) // Dynamically changes the instructor's volume
    {
        audioMixer.SetFloat("Instructor Voice", volume);
    }

    public void moodUpdate_Canvas() //Updates the user about their mood change
    {
        if (boxBreath_timeline.state != PlayState.Playing && lionsBreath_timeline.state != PlayState.Playing && _478Breath_timeline.state != PlayState.Playing)
        {
            menuCanvas.SetActive(false); // disable the menu in case its open
            moodCanvas.SetActive(true); // enable a panel with information about the user's mood

            float new_moodValue = GlobalControl.Instance.moodValue; // Take the value from the global class to display it
            if (new_moodValue != old_moodValue)
                moodText.SetText("Your mood changed from " + old_moodValue + " to " + new_moodValue);  // change the text value of a UI text component
            else
                moodText.SetText("Your mood has not changed..");  // change the text value of a UI text component
        }
           
    }
}
