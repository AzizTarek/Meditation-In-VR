using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
   public Dialogue dialogue; // instance of the dialogue class

    public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // find the dialogue manager and start the dialogue
	}

	 // Trigger Collision Detection
    void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Player")  // If the player collided with this gameobject
        {
            if (!FindObjectOfType<DialogueManager>().introductoryConvEnded)
                TriggerDialogue();           
        }
    }

    void OnTriggerExit(Collider col) 
    {
         if (col.gameObject.tag == "Player") // if the player exits the area of the object's collider
        {
             if (!FindObjectOfType<DialogueManager>().introductoryConvEnded)
                 FindObjectOfType<DialogueManager>().EndDialogue(); // end the dialogue           
        }
    }
}
