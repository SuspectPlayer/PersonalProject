using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlayerWhenTouchingWalls : MonoBehaviour
{
    RaycastHit hit;
    public ExplodePlayer explodePlayer;
    public AudioSource gameSound;
    StatsCounter stats;
    bool ready;
    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<StatsCounter>();
        gameSound = stats.GetComponent<AudioSource>();
        ready = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ready)
        {
            // Raycast to ground
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.transform.CompareTag("Wall"))
                {
                    StartCoroutine(ExplodePlayer());
                    Debug.Log("Player over wall");
                }
            }
        }
    }

    private IEnumerator ExplodePlayer()
    {
        explodePlayer.ExplodeNow();
        ready = false;
        gameSound.Play();
        yield return new WaitForSeconds(3);
        ready = true;
    }
}
