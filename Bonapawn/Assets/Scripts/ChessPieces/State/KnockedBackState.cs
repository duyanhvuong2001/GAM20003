using UnityEngine;

namespace Assets.Scripts.ChessPieces.State
{
    public class KnockedBackState : EnemyState
    {
        private float knockBackTime = 0.1f;
        private float lastKnockBack;
        private bool hit;
        public KnockedBackState(ChessPiece enemy) : base(enemy)
        {
            hit = false;
        }

        public override ENEMY_STATES UpdateState()
        {
            if(!hit)
            {
                lastKnockBack = Time.time;
                hit = true;
            }
            if(Time.time - lastKnockBack < knockBackTime)
            {
                Enemy.transform.Translate(Enemy.knockedBackDirection);
                Enemy.knockedBackDirection = Vector3.Lerp(Enemy.knockedBackDirection, Vector3.zero, Enemy.knockedBackRecoverySpeed);
                return ENEMY_STATES.KNOCKED_BACK;
            }
            else
            {
                hit = false;
                return ENEMY_STATES.WAIT;
            }
            
            
        }
    }
}
