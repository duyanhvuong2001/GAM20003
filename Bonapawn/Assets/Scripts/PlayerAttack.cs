using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class PlayerAttack : MonoBehaviour
{
    public float attackDuration = 20f;
    public float attackDelay = 10f;
    public float attackDurationActive = 0f;
    public float attackDelayActive = 0f;
    public Animator anim;

    public GameObject atkObj1;
    public GameObject atkObj2;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        atkObj1.SetActive(false);
        atkObj2.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {

            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
               //180
               0
           );
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                0
            );
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                90
            );
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                270
            );
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
           attackNormal();
        }

        if(attackDurationActive > 0f)
        {
            attackDurationActive -= 1f * Time.deltaTime;
            if (attackDurationActive <= 0f)
            {
                attackDelayActive = attackDelay;
                atkObj1.SetActive(false);
                atkObj2.SetActive(false);
            }
        }

        if(attackDelayActive > 0f)
        {
            attackDelayActive -= 1f * Time.deltaTime;
        }
    }

    void attackNormal()
    {
        
        if (attackDelayActive <= 0f && attackDurationActive <= 0)
        {
            anim.SetTrigger("attack");

            atkObj1.SetActive(true);
            atkObj2.SetActive(true);
            attackDurationActive = attackDuration;

            audioSource.pitch = 1;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
        
    }
}
