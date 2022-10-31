

namespace Assets.Scripts.ChessPieces.State
{
    public class KnockedBackState : EnemyState
    {
        public KnockedBackState(ChessPiece enemy) : base(enemy)
        {

        }

        public override ENEMY_STATES UpdateState()
        {

            return ENEMY_STATES.KNOCKED_BACK;
        }
    }
}
