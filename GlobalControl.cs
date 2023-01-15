using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour //Class that holds data that can be accessed across diferrent scenes
{
   public static GlobalControl Instance; // Static instance of this class
   public float moodValue; //The value that the user chose from the question 'how are you feeling'

    void Awake() // ensures that only one instance exists at a time
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

   
}
