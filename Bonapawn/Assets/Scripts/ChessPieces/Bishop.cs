using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ChessPieces
{
    public class Bishop : ChessPiece
    {
        protected override void Awake()
        {
            base.Awake();
            behaviours.Add(new DiagonalMoveBehaviour(5));
            moveCooldown = 1.5f;
        }
    }
}
