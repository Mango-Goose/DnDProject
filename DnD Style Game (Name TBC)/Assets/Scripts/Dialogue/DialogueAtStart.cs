using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAtStart : MonoBehaviour
{
    [SerializeField] string[] sentences;
    [SerializeField] DialogueManager dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.LoadSentences(sentences);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
