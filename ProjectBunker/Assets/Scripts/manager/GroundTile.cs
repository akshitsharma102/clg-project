using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        GroundSpawn.groundSpawn.SpawnTiles();
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        
    }
}
