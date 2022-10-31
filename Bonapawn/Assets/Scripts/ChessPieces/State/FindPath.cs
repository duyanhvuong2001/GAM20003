using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ChessPieces
{
    internal class FindPath : EnemyState
    {
        public FindPath(ChessPiece enemy) : base(enemy)
        {

        }
        public override ENEMY_STATES UpdateState()
        {
            Enemy.FindPath();
            return ENEMY_STATES.MOVE_CHESS_PIECE;
        }
    }
}
