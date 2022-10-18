using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoveBehaviour : ChessBehaviour
{
    private int _horizontalLimit;

    public HorizontalMoveBehaviour(int horizontalLimit) : base()
    {
        _horizontalLimit = horizontalLimit;
    }

    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition, BoxCollider2D boxCollider)
    {
        List<Path> paths = new List<Path>();

        bool leftBlock = false;
        bool rightBlock = false;
        for (int i = 1; i <= _horizontalLimit; i++)
        {
            //2 paths on the opposite side
            if(!leftBlock)
            {
                Vector3 leftPath = currentPosition + new Vector3(i, 0, 0);
                if(PathAvailable(currentPosition, leftPath, boxCollider))
                {
                    paths.Add(new Path(leftPath));
                }
                else
                {
                    leftBlock = true;
                }
            }

            if(!rightBlock)
            {
                Vector3 rightPath = currentPosition + new Vector3(-i, 0, 0);

                if (PathAvailable(currentPosition, rightPath, boxCollider))
                {
                    paths.Add(new Path(rightPath));
                }
                else
                {
                    rightBlock = true;
                }
            }
          
        }

        return paths;
    }
}
