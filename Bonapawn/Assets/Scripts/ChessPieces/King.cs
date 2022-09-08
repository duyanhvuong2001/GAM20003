using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    protected override void Awake()
    {
        base.Awake();
        behaviours.Add(new KingMoveBehaviour());
    }
}
