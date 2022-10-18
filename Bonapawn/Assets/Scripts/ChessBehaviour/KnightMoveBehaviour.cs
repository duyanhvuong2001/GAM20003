using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMoveBehaviour : ChessBehaviour
{
    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition, BoxCollider2D boxCollider)
    {
        List<Path> availablePaths = new List<Path>();
        //move up paths
        List<Path> moveUpPaths = new List<Path>
        {
            new Path(new Vector3(1,2,0)+ currentPosition),
            new Path(new Vector3(-1,2,0) + currentPosition)
        };
        //Add to the list of paths
        availablePaths.AddRange(moveUpPaths);

        //move down paths
        List<Path> moveDownPaths = new List<Path>
        {
            new Path(new Vector3(1,-2,0)+ currentPosition),
            new Path(new Vector3(-1,-2,0)+ currentPosition)
        };
        //Add to the list of paths
        availablePaths.AddRange(moveDownPaths);

        //move left paths
        List<Path> moveLeftPaths = new List<Path>
        {
            new Path(new Vector3(-2,1,0)+ currentPosition),
            new Path(new Vector3(-2,-1,0)+ currentPosition)
        };
        //Add to the list of paths
        availablePaths.AddRange(moveLeftPaths);

        //move right paths
        List<Path> moveRightPaths = new List<Path>
        {
            new Path(new Vector3(2,1,0)+ currentPosition),
            new Path(new Vector3(2,-1,0)+ currentPosition)
        };
        //Add to the list of paths
        availablePaths.AddRange(moveRightPaths);

        List<Path> pathsToRemove = new List<Path>();

        foreach(Path path in availablePaths)
        {
            if(!PathAvailable(currentPosition,path.Location,boxCollider))
            {
                pathsToRemove.Add(path);
            }
        }

        foreach(Path pathToRemove in pathsToRemove)
        {
            availablePaths.Remove(pathToRemove);
        }

        return availablePaths;

    }
}
