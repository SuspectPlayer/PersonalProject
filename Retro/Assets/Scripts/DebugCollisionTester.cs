using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCollisionTester : MonoBehaviour
{
    public string objectName;
    private void Start()
    {
        objectName = transform.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(objectName + "'s Trigger hit by " + other + " on the " + other.gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(objectName + "'s Collider hit by " + collision + " on the " + collision.gameObject.name);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(objectName + "'s Controller hit by " + hit + " on the " +hit.gameObject.name);
    }
}
