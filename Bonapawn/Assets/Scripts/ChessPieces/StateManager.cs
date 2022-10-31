using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ChessPieces.State;
using UnityEngine;
using Unity;

namespace Assets.Scripts.ChessPieces
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField]
        private ChessPiece enemy;
        [SerializeField]
        private float moveCD;

        EnemyState currentState;
        Wait waitState;
        Scout scoutState;
        LocatePlayer locatePlayerState;
        FindPath findPathState;
        Move moveState;
        KnockedBackState knockedBackState;

        ENEMY_STATES currentStateEnum;
        
        private void Awake()
        {
            waitState = new Wait(enemy,moveCD);
            scoutState = new Scout(enemy);
            locatePlayerState = new LocatePlayer(enemy);
            findPathState = new FindPath(enemy);
            moveState = new Move(enemy);
            knockedBackState = new KnockedBackState(enemy);

            //Set current state
            currentState = waitState;
        }

        private void Update()
        {
            switch (currentStateEnum)
            {
                case ENEMY_STATES.WAIT:
                    currentState = waitState;
                    break;
                case ENEMY_STATES.SCOUT:
                    currentState = scoutState;
                    break;
                case ENEMY_STATES.LOCATE_PLAYER:
                    currentState = locatePlayerState;
                    break;
                case ENEMY_STATES.FIND_PATH:
                    currentState = findPathState;
                    break;
                case ENEMY_STATES.MOVE_CHESS_PIECE:
                    currentState = moveState;
                    break;
                case ENEMY_STATES.KNOCKED_BACK:
                    currentState = knockedBackState;
                    break;
            }
            currentStateEnum = currentState.UpdateState();
            Debug.Log(currentStateEnum.ToString());
        }



        public void SetState(ENEMY_STATES state)
        {
            currentStateEnum = state;
            Debug.Log("KNOCKED");
        }



    }
}
