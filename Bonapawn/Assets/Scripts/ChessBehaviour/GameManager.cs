using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton instance
    public static GameManager instance;

    //References
    public Vector3 playerPosition;

    private void Awake()
    {
        if(GameManager.instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
}
