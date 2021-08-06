using System.Collections;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public static GroundSpawn groundSpawn;
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    void Start()
    {
        groundSpawn = this;
        for (int i = 0; i < 2; i++)
        {
            SpawnTiles();
        }
    }

    public void SpawnTiles()
    {
        GameObject temp =  Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }
    
}
