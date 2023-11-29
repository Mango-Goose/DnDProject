using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;

    [SerializeField] public Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); 
    }

    public void LoadSentences(string[] newSentences)
    {
        foreach (string sentence in newSentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            FinishDialogue();
        }
        else
        {
            dialogueText.text = sentences.Peek();
            sentences.Dequeue();
        }
    }

    public void FinishDialogue()
    {
        //set dialogue panel animation and change state so player can start moving and it doesn't stay on the HUD
        dialogueText.text = null;
        Debug.Log("FInished");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
