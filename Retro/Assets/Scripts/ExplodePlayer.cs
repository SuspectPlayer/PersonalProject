using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlayer : MonoBehaviour
{
    StatsCounter stats;
    public MovePlayer player;
    public List<Transform> partsList;
    public float force = 2;
    public float radius = 2;
    public float lift = 2;

    public AudioSource gameSound;
    private void Start()
    {
        player = GetComponent<MovePlayer>();
        stats = FindObjectOfType<StatsCounter>();
        gameSound = stats.GetComponent<AudioSource>();
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            gameSound.Play();
            ExplodeNow();
            player.ChangePlayerSpeed(4);
            hit.gameObject.GetComponent<ExplodeEnemy>().HitBySomething();
        }
        if (hit.gameObject.CompareTag("Bridge"))
        {
            gameSound.Play();
            ExplodeNow();
            player.ChangePlayerSpeed(4);
            hit.gameObject.GetComponent<ExplodeEnemy>().HitBySomething();
        }

    }
    
    
    //private void OnCollisionEnter(Collision collision)
    //{

    //        if (collision.gameObject.CompareTag("Enemy"))
    //        {
    //        gameSound.Play();
    //        ExplodeNow();
    //        player.ChangePlayerSpeed(4);
    //        collision.gameObject.GetComponent<ExplodeEnemy>().HitBySomething();
    //        }
    //        if (collision.gameObject.CompareTag("Bridge"))
    //        {
    //        gameSound.Play();
    //        ExplodeNow();
    //        player.ChangePlayerSpeed(4);
    //        collision.gameObject.GetComponent<ExplodeEnemy>().HitBySomething();
    //        }

    //}

    public void ExplodeNow()
    {
        player.audioSource.enabled = false;
        foreach (Transform part in partsList)
        {
            part.GetComponent<Rigidbody>().isKinematic = false;
            part.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
        }
        StartCoroutine(DestroyPlayer());
    }

    public IEnumerator DestroyPlayer()
    {
        stats.LoseLife();
        player.enabled = false;
        yield return new WaitForSeconds(1);
        stats.RespawnPlayer();       
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

}
