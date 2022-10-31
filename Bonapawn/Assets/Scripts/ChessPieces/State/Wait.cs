using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ChessPieces.State
{
    public class Wait : EnemyState
    {
        private float _moveCD;
        public Wait(ChessPiece enemy, float moveCD) : base(enemy)
        {
            _moveCD = moveCD;
        }
        public override ENEMY_STATES UpdateState()
        {
            if(Time.time - Enemy.lastMove > _moveCD)
            {
                Debug.Log(_moveCD);
                return ENEMY_STATES.LOCATE_PLAYER;
            }
            else
            {
                return ENEMY_STATES.WAIT;
            }
        }
    }
}
