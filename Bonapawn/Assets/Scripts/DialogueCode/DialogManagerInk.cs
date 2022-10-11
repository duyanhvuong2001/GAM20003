using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogManagerInk : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    //[SerializeField] private TextMeshProUGUI dialogueText;
    
    [SerializeField] private Text dialogueText;

    public Text nameText;

    private Story currentStory;

    private bool dialogueIsPlaying;

    private static DialogManagerInk instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogManagerInk GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }
    private void update()
    {
        //will return right away if dialogue is not playing 
        if(!dialogueIsPlaying)
        {
            return;
        }
        else
        {
             ContinueStory();
        }
           
    }

    public void EnterDialogueMode(TextAsset InkJSON)
    {
        
        currentStory = new Story(InkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        
        ContinueStory();

    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
