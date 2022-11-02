using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogManagerInk : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    //[SerializeField] private TextMeshProUGUI dialogueText;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    //[SerializeField] private Text piece;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;
    
    public Animator animator;

    private Story currentStory;
    
    public string piece;

    public ChargeManager chargers;

    public bool dialogueIsPlaying{ get; private set;}

    private static DialogManagerInk instance;

    private GameObject[] allHearts;

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

    public void setPiece(string NewPiece){
        piece = NewPiece;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all choices

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void update()
    {
        //will return right away if dialogue is not playing 
        if(!dialogueIsPlaying && !DialogManagerInk.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        else
        {
            ContinueStory();
        }
           
    }

    public void EnterDialogueMode(TextAsset InkJSON , string NPCName)
    {
        animator.SetBool("IsOpen", true);
        dialoguePanel.SetActive(true);
        nameText.text = NPCName;
        //Debug.Log("works");
        
        currentStory = new Story(InkJSON.text);
        dialogueIsPlaying = true;
       
        
        ContinueStory();

    }

    public void ExitDialogueMode()
    {
        animator.SetBool("IsOpen", false);
        dialogueIsPlaying = false;
        Debug.Log("exit dialogue");
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        GameObject[] allHearts = GameObject.FindGameObjectsWithTag("heart");
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
           
            dialogueText.text = currentStory.Continue();

            DisplayChoices();
        }
        else
        {
            Debug.Log(piece);
            powerUp(piece);
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);

        }

        int index = 0;

        //enable and init the choices up to the amount of choices for the line of dialogue
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index ++;

        }

        //hides choices 

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());


    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    public void powerUp(string NPCPostion){
    
        if (NPCPostion == "knight"){
            //chargers.knightCharges ++;
            chargers.GetComponent<ChargeManager>().knightCharges ++;
        }
        else if (NPCPostion == "bishop"){
           // chargers.bishopCharges ++;
           chargers.GetComponent<ChargeManager>().bishopCharges ++;
        }
        else if (NPCPostion == "rook"){
           //chargers.rookCharges ++;
           chargers.GetComponent<ChargeManager>().rookCharges ++;
        }

    }
}
