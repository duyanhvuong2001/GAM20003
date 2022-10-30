using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pDamaged : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("collided w enemy");
            gameController.TakeDamage();
        }
    }
}
