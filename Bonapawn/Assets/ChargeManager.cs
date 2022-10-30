using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ChargeManager : MonoBehaviour
{
    public int rookCharges;
    public int bishopCharges;
    public int knightCharges;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (rookCharges > 0)
            {
                if(gameObject.GetComponent<PlayerAttackRook>().attackRook())
                {
                    rookCharges -= 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (bishopCharges > 0)
            {
                if (gameObject.GetComponent<PlayerAttackBishop>().attackBishop())
                {
                    bishopCharges -= 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (knightCharges > 0)
            {
                if (gameObject.GetComponent<PlayerAttackKnight>().attackKnight())
                {
                    knightCharges -= 1;
                }
            }
        }
    }
}
