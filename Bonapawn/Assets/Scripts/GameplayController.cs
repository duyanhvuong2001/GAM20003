using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public int maxLives = 3;
    private int playerLives;

    public Text lifeText;
    //private string lifeOutput = "Lives - ";
    private int damageDelay = 0;

    private GameObject playerObject;
    private GameObject playerBase;
    private ChargeManager chargeMan;
    private PlayerMovement pMove;

    public Text rookText;
    public Text bishopText;
    public Text knightText;
    public GameObject[] hearts;
    public int respawn;

    public Image dImg;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = maxLives;
        //lifeText.text = lifeOutput + playerLives;

        playerObject = GameObject.Find("playerUpdated");
        playerBase = GameObject.Find("base");
        if (playerBase != null)
        { chargeMan = playerBase.GetComponent<ChargeManager>(); }

        if (playerObject != null)
        { pMove = playerObject.GetComponent<PlayerMovement>(); }

        if (dImg != null)
        { dImg.color = new Color(dImg.color.r, dImg.color.g, dImg.color.b, 0f); }

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

        if (dImg != null)
        {
            var tempColor = dImg.color;
            if (tempColor.a > 0f)
            {
                tempColor.a -= 0.02f;
                dImg.color = tempColor;
            }
        }

    }

    public void TakeDamage()
    {
        if (damageDelay <= 0)
        {
            Destroy(hearts[playerLives-1].gameObject);
            if(playerLives>1){
                //reduce lives
                playerLives--;
                //knocks player back
                pMove.pKnockback();
                //makes the damage overlay image visible
                dImg.color = new Color(dImg.color.r, dImg.color.g, dImg.color.b, 0.3f);
                //starts player invuln time
                damageDelay = 30;
            } else{
                respawn = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(respawn);
            }
        }
    }

    private void setText()
    {
        //lifeText.text = lifeOutput + playerLives;
        rookText.text = chargeMan.rookCharges.ToString();
        bishopText.text = chargeMan.bishopCharges.ToString();
        knightText.text = chargeMan.knightCharges.ToString();
    }
}
