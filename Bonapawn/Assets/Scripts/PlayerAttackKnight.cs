using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class PlayerAttackKnight : MonoBehaviour
{
    private float attackDuration = 0.4f;
    public float attackDelay = 1f;
    public float attackDurationActive = 0f;
    public float attackDelayActive = 0f;
    public float charges = 5;

    public GameObject atkObjN1;
    public GameObject atkObjN2;
    public GameObject atkObjE1;
    public GameObject atkObjE2;
    public GameObject atkObjS1;
    public GameObject atkObjS2;
    public GameObject atkObjW1;
    public GameObject atkObjW2;


    // Start is called before the first frame update
    void Start()
    {
        atkObjN1.SetActive(false);
        atkObjN2.SetActive(false);
        atkObjE1.SetActive(false);
        atkObjE2.SetActive(false);
        atkObjS1.SetActive(false);
        atkObjS2.SetActive(false);
        atkObjW1.SetActive(false);
        atkObjW2.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
        }

        if (attackDurationActive > 0f)
        {
            attackDurationActive -= 1f * Time.deltaTime;
            if (attackDurationActive <= 0f)
            {
                attackDelayActive = attackDelay;
                atkObjN1.SetActive(false);
                atkObjN2.SetActive(false);
                atkObjE1.SetActive(false);
                atkObjE2.SetActive(false);
                atkObjS1.SetActive(false);
                atkObjS2.SetActive(false);
                atkObjW1.SetActive(false);
                atkObjW2.SetActive(false);
            }
        }

        if (attackDelayActive > 0f)
        {
            attackDelayActive -= 1f * Time.deltaTime;
        }
    }

    public bool attackKnight()
    {
        if (attackDelayActive <= 0f && attackDurationActive! <= 0f)
        {
            atkObjN1.SetActive(true);
            atkObjN2.SetActive(true);
            atkObjE1.SetActive(true);
            atkObjE2.SetActive(true);
            atkObjS1.SetActive(true);
            atkObjS2.SetActive(true);
            atkObjW1.SetActive(true);
            atkObjW2.SetActive(true);
            attackDurationActive = attackDuration;
            return true;
        }
        else { return false; }
    }
}
