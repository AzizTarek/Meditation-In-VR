using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Editable from the inspector
public class Dialogue
{
   public string name; // name of the instructor
   [TextArea(3,10)]
   public string[] sentences; // array of text sentences
   public AudioClip[] audioSentences; // array of audio sources
}
