using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;

    public float speed = 30;
    public float rotationSpeed = 40;
    public Vector3 destination, origin;
    public bool chopper;
    public bool ship;
    public bool jet;

    public bool isActive;
    void Start()
    {       
        foreach (Transform point in points)
        {
            point.parent = null;
        }
        if (ship || chopper)
        {
            GotoNextPoint();
        }
        else
        {
            ResetPosition();
        }
    }

    public void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the enemy to go to the currently selected destination.
        destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;

    }
    public void ResetPosition()
    {
        origin = points[0].position;
        destination = points[1].position;
        transform.position = origin;
    }

    void Update()
    {
        if (!jet && isActive)
        {
            // Move enemy and rotate towards destination
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(destination), Time.deltaTime * rotationSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.LookAt(destination);

            // Choose between resetting or moving to next destination

            if (Vector3.Distance(transform.position, destination) < 3)
            {
                if (jet)
                {
                    ResetPosition();
                }
                else
                {
                    GotoNextPoint();
                }

            }




        }
        if (jet)
        {
            // Move enemy and rotate towards destination
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(destination), Time.deltaTime * rotationSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.LookAt(destination);

            // Choose between resetting or moving to next destination

            if (Vector3.Distance(transform.position, destination) < 3)
            {
                if (jet)
                {
                    ResetPosition();
                }
                else
                {
                    GotoNextPoint();
                }

            }




        }
    }
}

    
    
    
    
    

