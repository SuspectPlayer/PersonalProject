using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveEnemyJet : MonoBehaviour
{
    public float speed=30;
    public Transform destination;
    public Transform origin;
    public bool switched;
    private void Start()
    {
        origin.parent = null;
        destination.parent = null;
        transform.position = origin.position;
    }
   
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        float distance = Vector3.Distance(transform.position, destination.position);
        if (distance < 3)
        { 
            transform.position = origin.position;
        }
        
    }
}
