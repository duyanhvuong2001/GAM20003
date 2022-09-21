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

    public override List<Path> ExploreAvailablePaths(Vector3 currentPosition)
    {
        List<Path> paths = new List<Path>();

        for(int i=1;i<=_verticalLimit;i++)
        {
            //2 paths on the ooposite side
            Path upperPath = new Path(currentPosition + new Vector3(0, i, 0));
            Path lowerPath = new Path(currentPosition + new Vector3(0, -i, 0));

            paths.Add(upperPath);
            paths.Add(lowerPath);
        }

        return paths;
    }
}
