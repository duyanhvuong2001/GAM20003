using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessBehaviour : MonoBehaviour
{
    public abstract List<Path> ExploreAvailablePaths(Vector3 currentPosition);
}
