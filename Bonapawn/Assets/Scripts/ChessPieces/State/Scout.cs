using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ChessPieces
{
    public class Scout : EnemyState
    {
        private bool playerDetected;
        public Scout(ChessPiece enemy) : base(enemy)
        {
            playerDetected = false;
        }
        public override ENEMY_STATES UpdateState()
        {
            if(playerDetected)
            {
                Enemy.SetHeadingLocation(Enemy.LocatePlayer());
            }
            else
            {
                if(Vector3.Distance(Enemy.transform.position, GameManager.instance.playerTransform.position) < 4.0f)
                {
                    Enemy.SetHeadingLocation(Enemy.LocatePlayer());
                    playerDetected = true;
                }
                else
                {
                    Enemy.SetHeadingLocation(Enemy.ScoutEndPoint);
                }
            }

            return ENEMY_STATES.FIND_PATH;
        }
    }
}
