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

    public GameObject atkObj1;
    public GameObject atkObj2;


    // Start is called before the first frame update
    void Start()
    {
        atkObj1.SetActive(false);
        atkObj2.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
               //180
               0
           );
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                0
            );
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                90
            );
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                270
            );
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (attackDelayActive <= 0f)
            {
                atkObj1.SetActive(true);
                atkObj2.SetActive(true);
                attackDurationActive = attackDuration;
            }
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
}
