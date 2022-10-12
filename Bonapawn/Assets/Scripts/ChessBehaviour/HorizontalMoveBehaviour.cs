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

        for (int i = 1; i <= _horizontalLimit; i++)
        {
            //2 paths on the opposite side
            Path leftPath = new Path(currentPosition + new Vector3(i, 0, 0));
            Path rightPath = new Path(currentPosition + new Vector3(-i, 0, 0));

            paths.Add(leftPath);
            paths.Add(rightPath);
        }

        return paths;
    }
}
