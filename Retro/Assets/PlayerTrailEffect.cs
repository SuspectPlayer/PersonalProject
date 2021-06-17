using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailEffect : MonoBehaviour
{
    public GameObject trail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            trail.SetActive(true);
            Debug.Log("Pressing up or down");
        }
        else
        {
            trail.SetActive(false);
        }
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            trail.SetActive(false);
            Debug.Log("Pressing L or R");
        }
        
    }
}
