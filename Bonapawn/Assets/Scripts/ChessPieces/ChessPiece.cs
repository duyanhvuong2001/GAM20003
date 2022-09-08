using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    //Private properties
    private string pieceName;
    protected List<ChessBehaviour> behaviours;

    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Vector3 originalSize;
    public float ySpeed = 0.5f;
    public float xSpeed = 0.75f;

    //Protected properties
    protected bool isAlive;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        originalSize = transform.localScale;
        isAlive = true;
    }

    protected void UpdatePosition(Vector3 input)
    {
        //Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //Swap sprite direction
        if (moveDelta.x > 0)
        {
            transform.localScale = originalSize;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-originalSize.x, originalSize.y, originalSize.z);
        }

        //Move the player
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
