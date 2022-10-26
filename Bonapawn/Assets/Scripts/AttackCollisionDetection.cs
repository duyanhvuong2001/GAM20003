using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class AttackCollisionDetection : MonoBehaviour
{
    public int dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< Updated upstream
        if(collision.tag == "enemy"){
            collision.SendMessage("TakeDamage", dmg);
        }
=======
        if(collision.tag == "enemy")
        {
            collision.SendMessage("TakeDamage", dmg);
        }
       
>>>>>>> Stashed changes
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
