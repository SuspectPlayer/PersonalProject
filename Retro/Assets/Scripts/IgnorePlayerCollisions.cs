using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollisions : MonoBehaviour
{
    Collider player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovePlayer>().GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Physics.IgnoreCollision(player, GetComponent<Collider>());
        }
    }
}
