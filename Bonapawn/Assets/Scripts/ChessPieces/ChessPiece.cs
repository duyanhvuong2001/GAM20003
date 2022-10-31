
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    //Private properties
    public Vector3 lastMovePos;
    private string pieceName;
    protected List<ChessBehaviour> behaviours;

    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Vector3 originalSize;
    private float speed = 4f;

    //Protected properties 
    protected bool isAlive;
    public ENEMY_STATES currentState;
    protected int health = 5;
    protected List<Path> pathMemory;

    //Enemy logic
    public float scoutRadius;
    protected bool playerDetected;
    public float lastMove;
    protected float moveCooldown;
    protected Vector3 playerCoordinates;
    protected Vector3 headingLocation;
    [SerializeField] private GameObject scoutPointGO;
     private Vector3 scoutStart;
     private Vector3 scoutEnd;
    protected Path targetPosition;
    const int MAX_PATH_MEMORY_CAPACITY = 10;

    //knocked back logic
    public Vector3 knockedBackDirection;
    private float knockedBackForce;
    public float knockedBackRecoverySpeed;

    //Set-up Awake functions
    protected virtual void Awake()
    {
        originalSize = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();   
        behaviours = new List<ChessBehaviour>();
        pathMemory = new List<Path>();

        pathMemory.Add(new Path(transform.position));
        playerDetected = false;
        isAlive = true;
        scoutRadius = 4;
        scoutStart = transform.position;
        scoutEnd = scoutPointGO.transform.position;
    }
    public Path TargetPos
    {
        get
        {
            return targetPosition;
        }
    }
    public Vector3 ScoutEndPoint
    {
        get
        {
            return scoutEnd;
        }
    }
    
    public float MoveCD
    {
        get
        {
            return moveCooldown;
        }
    }
    protected List<Path> FindPaths()
    {
        List<Path> paths = new List<Path>();
        foreach(ChessBehaviour behaviour in behaviours)
        {
            paths.AddRange(behaviour.ExploreAvailablePaths(transform.position, boxCollider));
        }
        // Debug.Log(paths.Count);

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
                    // Debug.Log("CDD" + path.Location.ToString());
                    // Debug.Log("MEMORY" + memoryPath.Location.ToString());
                    filteredPaths.Add(path);
                }
            }
        }
        
        foreach(Path path in filteredPaths)
        {
            paths.Remove(path);
        }
        // Debug.Log(paths.Count);

        return paths;
    }

    protected void UpdatePathMemory()
    {
        if(pathMemory.Count > MAX_PATH_MEMORY_CAPACITY)
        {
            
            pathMemory.RemoveAt(0);
        }

        pathMemory.Add(targetPosition);
        // Debug.Log(pathMemory.Count);
    }

    protected Path FindOptimizedPath(List<Path> paths, Vector3 destination)
    {
        Path optimizedPath = null;
        float maxUtilityValue = float.MinValue;

        for(int i=0;i<paths.Count;i++)
        {
            float pathUtility = CalculateUtilityPoint(paths[i], destination);
            if (pathUtility > maxUtilityValue)
            {
                maxUtilityValue = pathUtility;
                optimizedPath = paths[i];
                // Debug.Log(maxUtilityValue);
            }
        }

        return optimizedPath;
    }

    protected float CalculateUtilityPoint(Path p, Vector3 destination)
    {
        float utilityPoint = 0f;
        RaycastHit2D[] wallsHit;

        //Subtract utility point by distance
        utilityPoint -= Vector3.Distance(p.Location, destination);

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
    public void UpdatePosition(Vector3 destination)
    {
        float deltaX = destination.x - transform.position.x;
        
        if(deltaX > 0){
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
    }

    protected void SwapScoutPoint()
    {
        Vector3 temp = scoutStart;
        scoutStart = scoutEnd;
        scoutEnd = temp;

        scoutPointGO.transform.position = scoutEnd;
    }

    //Update function

   

    public void SetLastMove(float time)
    {
        lastMove = time;
    }

    public Vector3 LocatePlayer()
    {
        return playerCoordinates = GameManager.instance.playerTransform.position;
    }

    public void SetHeadingLocation(Vector3 location)
    {
        headingLocation = location;
    }

    public void FindPath()
    {
        //First find all possible paths
        List<Path> availablePaths = FindPaths();

        //Use those paths to find the most optimized one
        Path mostOptimizedPath = FindOptimizedPath(availablePaths, headingLocation);

        //Set the target to this path
        targetPosition = mostOptimizedPath;

        //Store the path to the enemy's memory
        UpdatePathMemory();
    }
}

public enum ENEMY_STATES
{
    WAIT,
    SCOUT,
    LOCATE_SCOUT_POINT,
    LOCATE_PLAYER,
    FIND_PATH,
    KNOCKED_BACK,
    MOVE_CHESS_PIECE,
    DIE
}
