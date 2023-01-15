using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeelingsSurvey : MonoBehaviour
{
    public float moodValue = 0; // An index for the user's mood
    public GameObject option1,option2,option3,option4,option5,option6,option7,option8,option9,option10; // UI Radio buttons

    void Update()
    {
        //The respective value is stored depending on which button was pressed
        if (option1.GetComponent<Toggle>().isOn)
            moodValue = 1;
        else if (option2.GetComponent<Toggle>().isOn)
            moodValue = 2;
        else if (option3.GetComponent<Toggle>().isOn)
            moodValue = 3;
        else if (option4.GetComponent<Toggle>().isOn)
            moodValue = 4;
        else if (option5.GetComponent<Toggle>().isOn)
            moodValue = 5;
        else if (option6.GetComponent<Toggle>().isOn)
            moodValue = 6;
        else if (option7.GetComponent<Toggle>().isOn)
            moodValue = 7;
        else if (option8.GetComponent<Toggle>().isOn)
            moodValue = 8;
        else if (option9.GetComponent<Toggle>().isOn)
            moodValue = 9;
        else if (option10.GetComponent<Toggle>().isOn)
            moodValue = 10;


        if (moodValue != 0)
            SaveData(); 
    }
    public void SaveData()
    {
        GlobalControl.Instance.moodValue = moodValue; //Save it to global control class for global access
    }
}
