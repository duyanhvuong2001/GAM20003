using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{

    public float health;
    public int scoreValue;
    private GameObject UI;



    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        //gc = UI.GetComponent<GameplayController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //gc.IncreaseScore(scoreValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            takeDamage();
        }
    }

    private void takeDamage()
    {
        health -= 1;
        //probably need to add some visual indication that they've taken damage
    }
}
