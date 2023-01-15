using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
[HideInInspector] public bool introductoryConvEnded = false; //boolean to indicate the introduction has ended
    public TextMeshProUGUI nameText; // Text UI gameobject
    public TextMeshProUGUI dialogueText;// Text UI gameobject
    private Queue<string> sentences; //Follows (FIFO) first in first out rules, a queue of text sentences
    public Animator animator; 
 [HideInInspector]  public AudioSource audioSource;
 [HideInInspector]   public Queue<AudioClip> audioSentences; // a queue of audio clips


    // Start is called before the first frame update
    void Start()
    {
        // instantiate both queues for later use
        sentences = new Queue<string>(); 
        audioSentences = new Queue<AudioClip>();
    }

    void Update()
    {
        if(animator.GetBool("IsOpen")) // If the panel with text that uses the animator is already open 
           if(Input.GetKeyDown(KeyCode.N))
            {
                DisplayNextSentence(); 
                PlayNextAudioSentence(); 
            }
    }
    public void StartDialogue(Dialogue dialogue) // starts the dialogue
    {
        animator.SetBool("IsOpen",true);
        nameText.text = dialogue.name;
        sentences.Clear(); //Clear any prior conversations
        audioSentences.Clear(); //Clear any prior conversations

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // Get the sentence from the array and store it in a queue
        }

        foreach (AudioClip aSentence in dialogue.audioSentences)
        {
            audioSentences.Enqueue(aSentence); // Get the audio clip from the array and store it in a queue
        }

        DisplayNextSentence();
        PlayNextAudioSentence();
    }

    public void DisplayNextSentence()// Show next text sentence
    { 
        if(sentences.Count == 0) // If no sentences are left then call the end dialogue method
        {
            EndDialogue();
            introductoryConvEnded = true;
            return;
        }

       string sentence = sentences.Dequeue();    // Bring up a sentence in a FIFO manner
       StopAllCoroutines();    // Stop coroutines before starting a new one to avoid confusion and desynchronization
       StartCoroutine(TypeSentence(sentence)); // Call type sentence as a coroutine which has the ability to spread tasks across different frames
    }

    public void PlayNextAudioSentence() // Play next audio clip
    {
        if(audioSentences.Count ==0) // If no audio clip are left to be played then dont run the next lines of code
            return;
         
        AudioClip audioSentence = audioSentences.Dequeue(); // Bring up an audio clip in a FIFO manner
       
        //Setup the audio source and play it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioSentence; 
        audioSource.Play(); 
    }

    IEnumerator TypeSentence (string sentence) // Creates a typing effect 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())  // Loops through each character of a sentence iteratively
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() // End dialogue
    {
        Debug.Log("Ended conversation"); 
        animator.SetBool("IsOpen",false);// Close the panel that contains the text instructions
        audioSource.Stop(); // Stop playing the audio source
        
    }


}
