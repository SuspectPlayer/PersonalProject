using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovePlayer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 500)
            {
                Destroy(gameObject);
            }
        }
        else 
        {
            player = FindObjectOfType<MovePlayer>().transform;

        }
    }
}
