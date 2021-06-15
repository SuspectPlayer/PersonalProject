using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChopperBlade : MonoBehaviour
{
    public float rotationSpeed = 40;
    void Update()
    {
        transform.Rotate(0,Time.deltaTime * rotationSpeed,0);
    }
}
