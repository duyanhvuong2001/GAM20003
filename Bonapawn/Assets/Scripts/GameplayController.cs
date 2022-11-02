using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public int maxLives = 3;
    public int playerLives;

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
        if(!PlayerPrefs.HasKey("lives") || playerLives == 0){
            playerLives = maxLives;
        }
        displayHearts(playerLives);
        Debug.Log("HERE: "+playerLives);
        //lifeText.text = lifeOutput + playerLives;
        

        playerObject = GameObject.Find("playerUpdated");
        playerBase = GameObject.Find("base");
        if (playerBase != null)
        { chargeMan = playerBase.GetComponent<ChargeManager>(); }

        if(!PlayerPrefs.HasKey("rook")){
            chargeMan.rookCharges = 3;
            chargeMan.knightCharges = 3;
            chargeMan.bishopCharges = 3;
        }

        if (playerObject != null)
        { pMove = playerObject.GetComponent<PlayerMovement>(); }

        if (dImg != null)
        { 
            dImg.color = new Color(dImg.color.r, dImg.color.g, dImg.color.b, 0f);
            dImg.enabled = false;
        }


    }

    void OnDisable()
{
    PlayerPrefs.SetInt("lives", playerLives);
    PlayerPrefs.SetInt("rook", chargeMan.rookCharges);
    PlayerPrefs.SetInt("knight", chargeMan.knightCharges);
    PlayerPrefs.SetInt("bishop", chargeMan.bishopCharges);

}

void OnEnable()
{
    playerLives  =  PlayerPrefs.GetInt("lives");

    GameObject playerBase = GameObject.Find("base");
    if (playerBase != null)
    { chargeMan = playerBase.GetComponent<ChargeManager>(); }
    chargeMan.rookCharges = PlayerPrefs.GetInt("rook");
    chargeMan.knightCharges = PlayerPrefs.GetInt("knight");
    chargeMan.bishopCharges = PlayerPrefs.GetInt("bishop");

}

private void displayHearts (int playerLives){

    GameObject[] allHearts = GameObject.FindGameObjectsWithTag("heart");

    //Color all hearts < playerLives 
    for (int i = 0; i < playerLives; i++)
    {
        Color c = allHearts[i].GetComponent<Image>().color;
        c.a = 1;
        allHearts[i].GetComponent<Image>().color = c;
    }

    //Decolor all hearts > playerLives 
    for (int i = playerLives; i < allHearts.Length; i++)
    {
        Color c = allHearts[i].GetComponent<Image>().color;
        c.a = 0;
        allHearts[i].GetComponent<Image>().color = c;
    }
    
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
                if(tempColor.a <= 0)
                {
                    dImg.enabled = false;
                }
            }

        }

    }

    public void TakeDamage()
    {
        if (damageDelay <= 0)
        {

            //Destroy(hearts[playerLives-1].gameObject);
            playerLives--;
            //Decrease no of displayed hearts
            Debug.Log("HELPPPPP"+playerLives);
            Color a = hearts[playerLives].gameObject.GetComponent<Image>().color;
            a.a = 0;
            hearts[playerLives].gameObject.GetComponent<Image>().color = a;

            if(playerLives>0){

                //knocks player back
                pMove.pKnockback();
                //makes the damage overlay image visible
                dImg.color = new Color(dImg.color.r, dImg.color.g, dImg.color.b, 0.3f);
                dImg.enabled = true;
                //starts player invuln time
                damageDelay = 30;
            } else{
                //death
                if (GameObject.Find("testAudio"))
                {
                    Destroy(GameObject.Find("testAudio"));
                }
                respawn = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(respawn);
                playerLives = maxLives;

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
