using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; Cursor.lockState = CursorLockMode.None; //After coming back to the main menu from a scene, menu can be clicked (its a fix to this issue)
    }

}
