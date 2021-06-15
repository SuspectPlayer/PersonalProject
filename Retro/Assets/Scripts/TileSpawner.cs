using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> spawnedTiles = new List<GameObject>();
    Vector3 nextSpawnPoint;
    public GameObject spawnedTile;
    int cooldown = 2;
    public void SpawnTile()
    {
        if (spawnedTiles.Count < 2)
        {
            StartCoroutine(SpawnTileStart());
        }
    }
    private void Start()
    {
        SpawnTile();
        Debug.Log("Started");
    }

    public IEnumerator SpawnTileStart()
    {
        // pick random tiles from list
        int randomIndex = Random.Range(0, tiles.Count);
        GameObject randomTile = tiles[randomIndex];

        // instantiate the randomtile and declare it as spawnedTile
        spawnedTile = Instantiate(randomTile, nextSpawnPoint, Quaternion.identity);
        spawnedTiles.Add(spawnedTile);

        // set the spawned tiles next spawn point position
        nextSpawnPoint = spawnedTile.transform.GetChild(2).position;
        yield return new WaitForSeconds(cooldown);
       
    }
}
