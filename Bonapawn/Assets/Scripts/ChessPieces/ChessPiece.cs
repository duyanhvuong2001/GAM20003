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
    private float speed = 4f;

    //Protected properties 
    protected bool isAlive;
    protected ENEMY_STATES currentState;
    protected int health = 5;
    protected List<Path> pathMemory;

    //Enemy logic
    protected float lastMove;
    protected float moveCooldown;
    protected Vector3 playerCoordinates;
    protected Path targetPosition;
    const int MAX_PATH_MEMORY_CAPACITY = 10;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        originalSize = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();   
        behaviours = new List<ChessBehaviour>();
        pathMemory = new List<Path>();

        pathMemory.Add(new Path(transform.position));

        isAlive = true;
    }

    protected List<Path> FindPaths()
    {
        List<Path> paths = new List<Path>();
        foreach(ChessBehaviour behaviour in behaviours)
        {
            paths.AddRange(behaviour.ExploreAvailablePaths(transform.position, boxCollider));
        }
        Debug.Log(paths.Count);

        paths = FilterPaths(paths);
        return paths;;
    }

    protected List<Path> FilterPaths(List<Path> paths)
    {
        List<Path> filteredPaths = new List<Path>();

        foreach(Path path in paths)
        {
            foreach(Path memoryPath in pathMemory)
            {
                
                if (memoryPath.Location.ToString() == path.Location.ToString())
                {
                    Debug.Log("CDD" + path.Location.ToString());
                    Debug.Log("MEMORY" + memoryPath.Location.ToString());
                    filteredPaths.Add(path);
                }
            }
        }
        
        foreach(Path path in filteredPaths)
        {
            paths.Remove(path);
        }
        Debug.Log(paths.Count);

        return paths;
    }

    protected void UpdatePathMemory()
    {
        if(pathMemory.Count > MAX_PATH_MEMORY_CAPACITY)
        {
            
            pathMemory.RemoveAt(0);
        }

        pathMemory.Add(targetPosition);
        Debug.Log(pathMemory.Count);
    }

    protected Path FindOptimizedPath(List<Path> paths)
    {
        Path optimizedPath = null;
        float maxUtilityValue = float.MinValue;

        for(int i=0;i<paths.Count;i++)
        {
            float pathUtility = CalculateUtilityPoint(paths[i]);
            if (pathUtility > maxUtilityValue)
            {
                maxUtilityValue = pathUtility;
                optimizedPath = paths[i];
                Debug.Log(maxUtilityValue);
            }
        }

        return optimizedPath;
    }

    protected float CalculateUtilityPoint(Path p)
    {
        float utilityPoint = 0f;
        RaycastHit2D[] wallsHit;

        //Subtract utility point by distance
        utilityPoint -= Vector3.Distance(p.Location, playerCoordinates);

        //Subtract utility point by the number of walls between that position and the player
        wallsHit = Physics2D.RaycastAll(
            p.Location,
            playerCoordinates,
            Vector3.Distance(p.Location, playerCoordinates),
            LayerMask.GetMask("Blocking")
            );

        foreach(RaycastHit2D wall in wallsHit)
        {
            utilityPoint -= 100;
        }

        if(wallsHit.Length > 0)
        {
            utilityPoint -= wallsHit[0].distance;
           
        }

        return utilityPoint;

    }
    protected void UpdatePosition(Vector3 destination)
    {
        float deltaX = destination.x - transform.position.x;
        
        if(deltaX>0){
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
    }

    //Update function

    protected virtual void Update()
    {
        ENEMY_STATES state = currentState;
        //Debug.Log(state);
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

                    //Store the path to the enemy's memory
                    UpdatePathMemory();

                    //set the next state
                    state = ENEMY_STATES.MOVE_CHESS_PIECE;

                    break;
                case ENEMY_STATES.MOVE_CHESS_PIECE:
                    if(targetPosition!=null)
                    {
                        if (transform.position != targetPosition.Location)
                        {
                            UpdatePosition(targetPosition.Location);


                            state = ENEMY_STATES.MOVE_CHESS_PIECE;
                        }
                        else
                        {
                            lastMove = Time.time;



                            state = ENEMY_STATES.WAIT;
                        }
                        
                    }
                    else
                    {
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
