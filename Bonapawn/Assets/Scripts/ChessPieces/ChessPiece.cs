using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    //Private properties
    private string pieceName;
    protected List<ChessBehaviour> behaviours;

    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Vector3 originalSize;
    private float speed = 2f;

    //Protected properties 
    protected bool isAlive;
    protected ENEMY_STATES currentState;
    protected int health = 5;
    //Enemy logic
    protected float lastMove;
    protected float moveCooldown;
    protected Vector3 playerCoordinates;
    protected Path targetPosition;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        originalSize = transform.localScale;
        behaviours = new List<ChessBehaviour>();
        isAlive = true;
    }

    protected List<Path> FindPaths()
    {
        List<Path> paths = new List<Path>();
        foreach(ChessBehaviour behaviour in behaviours)
        {
            paths.AddRange(behaviour.ExploreAvailablePaths(transform.position, boxCollider));
        }
        return paths;
    }

    protected Path FindOptimizedPath(List<Path> paths)
    {
        Path optimizedPath = null;
        float shortestDistance = float.MaxValue;
        for(int i=0;i<paths.Count;i++)
        {
            if (Vector3.Distance(paths[i].Location, playerCoordinates) < shortestDistance)
            {
                shortestDistance = Vector3.Distance(paths[i].Location, playerCoordinates);
                optimizedPath = paths[i];
                Debug.Log(shortestDistance);
            }
        }

        return optimizedPath;
    }
    protected void UpdatePosition(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
    }

    //Update function

    protected virtual void Update()
    {
        ENEMY_STATES state = currentState;
        Debug.Log(state);
        if (isAlive)
        {
            //Act based on current state
            switch(state)
            {
                case ENEMY_STATES.DIE:
                    isAlive = false;
                    break;
                case ENEMY_STATES.WAIT:
                    if(Time.time - lastMove > moveCooldown)//If finished the cooldown
                    {
                        state = ENEMY_STATES.LOCATE_PLAYER;
                    }
                    else
                    {
                        state = ENEMY_STATES.WAIT;
                    }
                    break;
                case ENEMY_STATES.LOCATE_PLAYER:
                    playerCoordinates = GameManager.instance.playerTransform.position;
                    state = ENEMY_STATES.FIND_PATH;
                    break;
                case ENEMY_STATES.FIND_PATH:
                    //First find all possible paths
                    List<Path> availablePaths = FindPaths();

                    //Use those paths to find the most optimized one
                    Path mostOptimizedPath = FindOptimizedPath(availablePaths);

                    //Set the target to this path
                    targetPosition = mostOptimizedPath;

                    //set the next state
                    state = ENEMY_STATES.MOVE_CHESS_PIECE;

                    break;
                case ENEMY_STATES.MOVE_CHESS_PIECE:
                    if(transform.position != targetPosition.Location)
                    {
                        UpdatePosition(targetPosition.Location);
                        state = ENEMY_STATES.MOVE_CHESS_PIECE;
                    }
                    else
                    {
                        lastMove = Time.time;
                        state = ENEMY_STATES.WAIT;
                    }
                    break;
            }

            //Finally update the current state
            currentState = state;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public enum ENEMY_STATES
{
    WAIT,
    LOCATE_PLAYER,
    FIND_PATH,
    MOVE_CHESS_PIECE,
    DIE
}
