using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerBox : MonoBehaviour
{
    public TileSpawner tileSpawner;
    
    private void Start()
    {
        tileSpawner = FindObjectOfType<TileSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tileSpawner != null)
            {
                tileSpawner.SpawnTile();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tileSpawner.spawnedTiles.Remove(tileSpawner.spawnedTile);
            Destroy(gameObject, 2);
        }
    }

}
