using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessBehaviour
{
    public abstract List<Path> ExploreAvailablePaths(Vector3 currentPosition);
}
