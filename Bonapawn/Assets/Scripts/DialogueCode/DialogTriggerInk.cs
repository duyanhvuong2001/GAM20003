using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerInk : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset InkJSON;

    [Header("Name")]
    [SerializeField] public string name;

    
    [Header("Piece")]
    [SerializeField] public string piece;

  


    private bool playerInRange;
   
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManagerInk>().EnterDialogueMode(InkJSON, name);
        FindObjectOfType<DialogManagerInk>().setPiece(piece);

        //Debug.Log(name);
        //Debug.Log(InkJSON.text);
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("enter trigger");
            playerInRange = true;
            piece = this.transform.parent.tag;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log(" exit trigger");
            Debug.Log(name);
            playerInRange = false;
        }
    }

}
