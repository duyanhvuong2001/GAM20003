using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    protected override void Awake()
    {
        base.Awake();
        behaviours.Add(new KnightMoveBehaviour());
        moveCooldown = 1.5f;
    }
}
