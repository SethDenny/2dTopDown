using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public AudioSource audiosource;

    private Queue<string> sentences;

    public bool isCutscene = false;

    public LevelChanger levelChanger;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        Debug.Log("DisplayNextSentence queued sentences: " + sentences.Count, gameObject);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }  
    
    IEnumerator TypeSentence (string sentence)
    {
        audiosource.Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds((float).05);

        }
        audiosource.Stop();
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        if(isCutscene == true)
        {
            levelChanger.nextScene = true;
        }
        
    }    
}
