using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamaged : MonoBehaviour
{
    private GameObject UI;
    private GameplayController gameController;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        if (UI != null)
        { gameController = UI.GetComponent<GameplayController>(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy" && UI != null)
        {
            gameController.TakeDamage();
        }
    }
}
