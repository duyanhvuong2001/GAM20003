using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class PlayerAttackBishop : MonoBehaviour
{
    private float attackDuration = 0.4f;
    public float attackDelay = 1f;
    public float attackDurationActive = 0f;
    public float attackDelayActive = 0f;
    public float charges = 3;

    public GameObject atkObjNE1;
    public GameObject atkObjNE2;
    public GameObject atkObjNE3;
    public GameObject atkObjSE1;
    public GameObject atkObjSE2;
    public GameObject atkObjSE3;
    public GameObject atkObjSW1;
    public GameObject atkObjSW2;
    public GameObject atkObjSW3;
    public GameObject atkObjNW1;
    public GameObject atkObjNW2;
    public GameObject atkObjNW3;

    // Start is called before the first frame update
    void Start()
    {
        atkObjNE1.SetActive(false);
        atkObjNE2.SetActive(false);
        atkObjNE3.SetActive(false);
        atkObjSE1.SetActive(false);
        atkObjSE2.SetActive(false);
        atkObjSE3.SetActive(false);
        atkObjSW1.SetActive(false);
        atkObjSW2.SetActive(false);
        atkObjSW3.SetActive(false);
        atkObjNW1.SetActive(false);
        atkObjNW2.SetActive(false);
        atkObjNW3.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        

        if (attackDurationActive < 0.3f && attackDurationActive > 0f)
        {
            atkObjNE2.SetActive(true);
            atkObjSE2.SetActive(true);
            atkObjSW2.SetActive(true);
            atkObjNW2.SetActive(true);
        }

        if (attackDurationActive < 0.2f && attackDurationActive > 0f)
        {
            atkObjNE3.SetActive(true);
            atkObjSE3.SetActive(true);
            atkObjSW3.SetActive(true);
            atkObjNW3.SetActive(true);
        }


        if (attackDurationActive > 0f)
        {
            attackDurationActive -= 1f * Time.deltaTime;
            if (attackDurationActive <= 0f)
            {
                attackDelayActive = attackDelay;
                atkObjNE1.SetActive(false);
                atkObjNE2.SetActive(false);
                atkObjNE3.SetActive(false);
                atkObjSE1.SetActive(false);
                atkObjSE2.SetActive(false);
                atkObjSE3.SetActive(false);
                atkObjSW1.SetActive(false);
                atkObjSW2.SetActive(false);
                atkObjSW3.SetActive(false);
                atkObjNW1.SetActive(false);
                atkObjNW2.SetActive(false);
                atkObjNW3.SetActive(false);
            }
        }

        if (attackDelayActive > 0f)
        {
            attackDelayActive -= 1f * Time.deltaTime;
        }
    }

    public bool attackBishop()
    {
        if (attackDelayActive <= 0f && attackDurationActive! <= 0f)
        {
            atkObjNE1.SetActive(true);
            atkObjSE1.SetActive(true);
            atkObjSW1.SetActive(true);
            atkObjNW1.SetActive(true);
            attackDurationActive = attackDuration;
            return true;
        }
        else { return false; }
    }
}
