using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMoveBehaviour : ChessBehaviour
{
    private int _limit;

    public DiagonalMoveBehaviour(int limit)
    {
        _limit = limit;
    }

    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition, BoxCollider2D boxCollider)
    {
        List<Path> paths = new List<Path>();
        //Limit the range of available moves
        for(int i=-_limit;i<=_limit;i++)
        {
            if(i!=0)
            {
                //A path with the same x,y relatively to the current pos
                Path upperPath = new Path(currentPosition + new Vector3(i, i, 0));

                //Another flipped path
                Path lowerPath = new Path(currentPosition + new Vector3(i, -i, 0));

                //add them to the list of paths
                paths.Add(upperPath);
                paths.Add(lowerPath);
            }
        }
        return paths;
    }
}
