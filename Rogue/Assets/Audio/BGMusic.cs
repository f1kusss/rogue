using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public static bool Spawned = false;
    
    
    
    void Awake()
    {
        if (Spawned)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            Spawned = true;
        }
    }
}
