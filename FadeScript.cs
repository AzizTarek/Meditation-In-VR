using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup1; // a canvas group component attached to a UI gameobject
    [SerializeField] private CanvasGroup myUIGroup2;// a canvas group component attached to a UI gameobject
    [SerializeField] private bool fadeIn = false;  // Boolean to fade in the game object
    [SerializeField] private bool fadeOut = false;// Boolean to fade out the game object

    public void ShowUI()
    {
        fadeIn = true; // enable the visibility of a ui gameobject by fading in 
    }

    public void HideUI()
    {
        fadeOut = true; // disable the visibility of a ui gameobject by fading out
    }

    public void Update()
    {
        if(fadeIn)  // /if a ui gameobject is fading in
        {
            if(myUIGroup2.alpha <1) 
            {
                myUIGroup2.alpha += Time.deltaTime; //increase the alpha value until the colour of the ui gameobject is completely solid
                if(myUIGroup2.alpha >=1)
                {
                    fadeIn = false; // stop fading in when the gameobject is solid
                }
            }
        }
        if (fadeOut) // /if a ui gameobject is fading out
        {
            if (myUIGroup1.alpha >0)
            {
                myUIGroup1.alpha -= Time.deltaTime; //decrease the alpha value until the colour of the ui gameobject is completely transparent
                if (myUIGroup1.alpha == 0)
                {
                    fadeOut = false; // stop fading out when the gameobject is transparent
                }
            }
        }
    }
}
