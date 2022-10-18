using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveBehaviour : ChessBehaviour
{
    private int _verticalLimit;

    public VerticalMoveBehaviour(int verticalLimit)
    {
        _verticalLimit = verticalLimit;
    }
    

    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition, BoxCollider2D boxCollider)
    {
        List<Path> paths = new List<Path>();

        bool upperBlock = false;
        bool lowerBlock = false;
        for(int i=1;i<=_verticalLimit;i++)
        { //2 paths on the ooposite side
            if (!upperBlock)
            {
                Vector3 upperPath = currentPosition + new Vector3(0, i, 0);

                if(PathAvailable(currentPosition, upperPath,boxCollider))
                {
                    paths.Add(new Path(upperPath));
                }
                else
                {
                    upperBlock = true;
                }
            }

            if (!lowerBlock)
            {
                Vector3 lowerPath = currentPosition + new Vector3(0, i, 0);

                if (PathAvailable(currentPosition, lowerPath, boxCollider))
                {
                    paths.Add(new Path(lowerPath));
                }
                else
                {
                    lowerBlock = true;
                }
            }
          
        }

        return paths;
    }
}
