using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ChessPieces
{
    public class Move : EnemyState
    {
        public Move(ChessPiece enemy) : base(enemy)
        {

        }
        public override ENEMY_STATES UpdateState()
        {
            if(Enemy.TargetPos!=null)
            {
                if(Enemy.transform.position != Enemy.TargetPos.Location)
                {
                    Enemy.UpdatePosition(Enemy.TargetPos.Location);
                    return ENEMY_STATES.MOVE_CHESS_PIECE;
                }
                else
                {
                    Enemy.SetLastMove(Time.time);

                    return ENEMY_STATES.WAIT;
                }
                
            }
            else
            {
                return ENEMY_STATES.WAIT;
            }
        }
    }
}
