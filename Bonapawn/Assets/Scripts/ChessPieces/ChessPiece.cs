using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChessPiece : MonoBehaviour
{
    //Properties
    private string pieceName;
    private List<ChessBehaviour> behaviours;
    private Vector3 position;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        position = transform.position;
    }

    protected void UpdatePosition(Vector3 target)
    {

    }
}
