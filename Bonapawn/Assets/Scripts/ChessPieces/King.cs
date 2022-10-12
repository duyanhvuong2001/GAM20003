using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    protected override void Awake()
    {
        base.Awake();
        behaviours.Add(new VerticalMoveBehaviour(1));
        behaviours.Add(new HorizontalMoveBehaviour(1));
        behaviours.Add(new DiagonalMoveBehaviour(1));
        moveCooldown = 1.5f;
    }



}
