using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class evokeDeath : MonoBehaviour
{
    public int health = 100;

    public int Respawn;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag.Equals("Player")){
            //maybe take life instead of reverting to start screen
            SceneManager.LoadScene(Respawn);
        }
    }


}
