using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ChessPieces;
using UnityEngine.SceneManagement;

public class EnemyDamaged : MonoBehaviour
{

    public int health = 3;
    public int scoreValue;
    private GameObject UI;
    private GameObject Damaged;
    private float delay;
    public Vector3 lastMovePos;
    [SerializeField] private StateManager stateManager;
    [SerializeField] private ChessPiece enemy;



    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        Damaged = GameObject.Find("damaged");
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

        if(delay > 0f)
        {
            delay -= 1f;
        }
        else
        {
            if (Damaged != null)
            {
                Damaged.SetActive(false);
            }
        }

        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "attack")
    //    {
    //        takeDamage();
    //    }
    //}

    // public int Respawn = SceneManager.GetActiveScene().buildIndex;
    // void OnCollisionEnter2D(Collision2D other){
    //     if(other.gameObject.tag.Equals("Player")){
    //         SceneManager.LoadScene(Respawn);
    //     }
    // }

    private void TakeDamage(int dmg)
    {
        if (delay <= 0)
        {
            health -= dmg;


            if (Damaged != null)
            {
                Damaged.SetActive(true);
            }
            delay = 20f;

            //Set animation
            gameObject.GetComponent<Animator>().SetTrigger("dmg");

            //Set push force
            enemy.knockedBackDirection = (GameManager.instance.playerTransform.position - transform.position).normalized * dmg*0.1f;

            //Set enemy State
            stateManager.SetState(ENEMY_STATES.KNOCKED_BACK);
            


        
        }
    }
}
