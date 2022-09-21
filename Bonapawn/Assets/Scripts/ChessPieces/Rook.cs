using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ChessPieces
{
    public class Rook : ChessPiece
    {
        protected override void Awake()
        {
            base.Awake();
            behaviours.Add(new VerticalMoveBehaviour(4));
            behaviours.Add(new HorizontalMoveBehaviour(4));
            moveCooldown = 1.5f;
        }
    }
}
