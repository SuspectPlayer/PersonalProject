using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private GameObject player;
    public GameObject[] enemies;
    [SerializeField] private float distance;
    [SerializeField] private float maxDistance = 300;
    [SerializeField] private float activeDistance = 80;
    GameObject childEnemy;
    bool spawned;
    private void Start()
    {
       
        player = FindObjectOfType<MovePlayer>().gameObject;
        
    }
    private void Update()
    {
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < maxDistance && !spawned)
            {
                SpawnRandomEnemy();

            }
            if (distance < activeDistance && spawned)
            {
                if (childEnemy != null)
                {
                    childEnemy.GetComponent<MoveEnemy>().isActive = true;
                }
            }
        }
       
    }
    void SpawnRandomEnemy()
    {
        int randomNumber = Random.Range(0, enemies.Length);
        
        GameObject enemy = Instantiate(enemies[randomNumber]);

        childEnemy = enemy;
        enemy.transform.position = transform.position;
        
        spawned = true;
    }
}
