using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public int maxLives = 3;
    private int playerLives;

    public Text lifeText;
    private string lifeOutput = "Lives - ";
    private int damageDelay = 0;

    private GameObject playerObject;
    private GameObject playerBase;
    private ChargeManager chargeMan;

    public Text rookText;
    public Text bishopText;
    public Text knightText;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = maxLives;
        lifeText.text = lifeOutput + playerLives;

        playerObject = GameObject.Find("playerUpdated");
        playerBase = GameObject.Find("base");
        if (playerBase != null)
        { chargeMan = playerBase.GetComponent<ChargeManager>(); }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damageDelay > 0)
        {
            damageDelay--;
        }

        if (playerLives <= 0 && playerObject != null)
        {
            playerObject.SetActive(false);
        }

        setText();

    }

    public void TakeDamage()
    {
        if (damageDelay <= 0)
        {
            playerLives--;
            damageDelay = 30;
        }
    }

    private void setText()
    {
        lifeText.text = lifeOutput + playerLives;
        rookText.text = chargeMan.rookCharges.ToString();
        bishopText.text = chargeMan.bishopCharges.ToString();
        knightText.text = chargeMan.knightCharges.ToString();
    }
}
