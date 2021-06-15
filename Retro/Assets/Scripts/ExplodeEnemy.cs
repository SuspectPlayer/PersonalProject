using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExplodeEnemy : MonoBehaviour
{
    SpawnPlayer spawn;
    StatsCounter stats;
    public TMP_Text scoreText;
    public DestroyEnemyParts ground;
    public List<Transform> partsList;
    public float force = 2;
    public float radius = 2;
    public float lift = 2;

    public int enemyPoints;
    bool enemyDied;
    private void Start()
    {
        spawn = FindObjectOfType<SpawnPlayer>();
        stats = FindObjectOfType<StatsCounter>();
        ground = FindObjectOfType<DestroyEnemyParts>();
    }
    public void FixedUpdate()
    {
        if (enemyDied)
        {
            if (transform.CompareTag("Bridge"))
            {
                Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 40);
                spawn.ChangeSpawnPoint(spawnPoint);
                Debug.Log("Checkpoint reached");
            }
            transform.tag = "Untagged";
            Destroy(gameObject);
        }
       
        
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
        if (hit.gameObject.CompareTag("Player"))
        {
            ExplodeNow();
        }
        if (hit.gameObject.CompareTag("Bullet"))
        {
            TMP_Text scoreTxt = Instantiate(scoreText, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity, transform.parent = null);
            if (transform.name.Contains("Jet"))
            {
                scoreTxt.text = "100";
                enemyPoints = 100;
            }
            if (transform.name.Contains("Chopper"))
            {
                scoreTxt.text = "60";
                enemyPoints = 60;
            }
            if (transform.name.Contains("Ship"))
            {
                scoreTxt.text = "30";
                enemyPoints = 30;
            }
            if (transform.name.Contains("Fuel"))
            {
                scoreTxt.text = "80";
                enemyPoints = 80;
            }

            ExplodeNow();
        }
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ExplodeNow();          
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TMP_Text scoreTxt = Instantiate(scoreText, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity, transform.parent = null);
            if (transform.name.Contains("Jet"))
            {
                scoreTxt.text = "100";
                enemyPoints = 100;
            }
            if (transform.name.Contains("Chopper"))
            {
                scoreTxt.text = "60";
                enemyPoints = 60;
            }
            if (transform.name.Contains("Ship"))
            {
                scoreTxt.text = "30";
                enemyPoints = 30;
            }
            if (transform.name.Contains("Fuel"))
            {
                scoreTxt.text = "80";
                enemyPoints = 80;
            }
            if (transform.name.Contains("Bridge"))
            {
                scoreTxt.text = "500";
                enemyPoints = 500;
            }

            
            ExplodeNow();
            
        }
    }
    

    public void ExplodeNow()
    {
        enemyDied = true;
        stats.AddPoints(enemyPoints);
        foreach (Transform part in partsList)
        {
            part.gameObject.tag = "Untagged";
            if(part.name == "Pivot")
            {
                part.GetComponent<RotateChopperBlade>().rotationSpeed = 200;
            }
            part.GetComponent<BoxCollider>().enabled = true;
            part.GetComponent<Rigidbody>().isKinematic = false;
            part.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
            part.parent = ground.transform;
            ground.unparentedPartsList.Add(part);
            

        }
        
    }
    public void HitBySomething()
    {
        ExplodeNow();
       
    }

    


}
