using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        RespawnPlayer();
        ChangeSpawnPoint(transform.position);
    }

    public void ChangeSpawnPoint(Vector3 position)
    {
        transform.position = position;
    }
    public void RespawnPlayer()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        
    }

    
}
