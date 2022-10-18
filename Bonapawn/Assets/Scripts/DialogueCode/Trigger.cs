using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset InkJSON;

    [Header("Name")]
    [SerializeField] public string name;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManagerInk>().EnterDialogueMode(InkJSON, name);
        Debug.Log(name);
        Debug.Log(InkJSON.text);
    }
}
