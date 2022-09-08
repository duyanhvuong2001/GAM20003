using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMoveBehaviour : ChessBehaviour
{
    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition)
    {
       List<Path> availablePaths = new List<Path>();
       for(int i=-1;i<2;i++)
        {
            for(int j=-1;j<2;j++)
            {
                if (i != 0 || j != 0)
                {
                    Path path = new Path(new Vector3(i, j, 0));
                    availablePaths.Add(path);
                }
            }
        }
        return availablePaths;
    }
}
