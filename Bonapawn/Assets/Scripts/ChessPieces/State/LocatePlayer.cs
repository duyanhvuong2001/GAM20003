using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ChessPieces.State
{
    public class LocatePlayer : EnemyState
    {
        public LocatePlayer(ChessPiece enemy) : base(enemy)
        {

        }
        public override ENEMY_STATES UpdateState()
        {
            Enemy.LocatePlayer();
            return ENEMY_STATES.SCOUT;
        }
    }
}
