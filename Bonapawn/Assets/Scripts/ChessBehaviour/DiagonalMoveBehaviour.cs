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
        //Limit variables
        bool northWestBlocked = false;
        bool southWestBlocked = false;
        bool southEastBlocked = false;
        bool northEastBlocked = false;
        //Limit the range of available moves
        for(int i=0;i<=_limit;i++)
        {
            if(i!=0)
            {
                if(!northWestBlocked)
                {
                    //Create a candidate destination
                    Vector3 candidatePath = currentPosition + new Vector3(-i, -i, 0);

                    //If the path to this candidate is available
                    if(PathAvailable(currentPosition,candidatePath,boxCollider))
                    {
                        Path northWestPath = new Path(candidatePath);

                        paths.Add(northWestPath);
                    }
                    else
                    {
                        northWestBlocked = true;
                    }
                }

                if (!southWestBlocked)
                {
                    //Create a candidate destination
                    Vector3 candidatePath = currentPosition + new Vector3(-i, i, 0);

                    //If the path to this candidate is available
                    if (PathAvailable(currentPosition, candidatePath, boxCollider))
                    {
                        Path southWestPath = new Path(candidatePath);

                        paths.Add(southWestPath);
                    }
                    else
                    {
                        southWestBlocked = true;
                    }
                }

                if (!southEastBlocked)
                {
                    //Create a candidate destination
                    Vector3 candidatePath = currentPosition + new Vector3(i, i, 0);

                    //If the path to this candidate is available
                    if (PathAvailable(currentPosition, candidatePath, boxCollider))
                    {
                        Path southEastPath = new Path(candidatePath);

                        paths.Add(southEastPath);
                    }
                    else
                    {
                        southEastBlocked = true;
                    }
                }

                if (!northEastBlocked)
                {
                    //Create a candidate destination
                    Vector3 candidatePath = currentPosition + new Vector3(i, -i, 0);

                    //If the path to this candidate is available
                    if (PathAvailable(currentPosition, candidatePath, boxCollider))
                    {
                        Path northEastPath = new Path(candidatePath);
                        paths.Add(northEastPath);
                    }
                    else
                    {
                        northEastBlocked = true;
                    }
                }
            }
        }
        return paths;
    }
}
