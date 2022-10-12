using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessBehaviour
{
    private RaycastHit2D hit;

    public abstract List<Path> ExploreAvailablePaths(Vector3 currentPosition, BoxCollider2D collider);

    public bool PathAvailable(Vector3 currentPosition, Vector3 destination, BoxCollider2D collider)
    {
        //Cast a box at the destination
        hit = Physics2D.BoxCast(
            currentPosition,
            collider.size,
            0,
            destination - currentPosition,
            Mathf
            );
    }
}
