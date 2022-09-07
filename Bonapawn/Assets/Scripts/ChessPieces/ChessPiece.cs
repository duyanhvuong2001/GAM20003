using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    //Private properties
    private string pieceName;
    private List<ChessBehaviour> behaviours;
    private Vector3 position;

    //Protected properties
    protected bool isAlive;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        position = transform.position;
        isAlive = true;
    }

    protected void UpdatePosition(Vector3 target)
    {

    }
}
