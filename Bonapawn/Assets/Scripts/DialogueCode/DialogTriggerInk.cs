using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerInk : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;


    private bool playerInRange;
   
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
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
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log(" exit trigger");
            playerInRange = false;
        }
    }

}
