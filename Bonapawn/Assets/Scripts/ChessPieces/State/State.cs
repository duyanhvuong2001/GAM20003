using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ChessPieces
{
    public abstract class EnemyState
    {
        ChessPiece _enemy;
        public EnemyState(ChessPiece enemy)
        {
            _enemy = enemy;
        }

        public ChessPiece Enemy
        {
            get { return _enemy; }
        }
        public abstract ENEMY_STATES UpdateState();
    }
}
