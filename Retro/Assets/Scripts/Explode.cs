using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public List<Transform> contactedParts = new List<Transform>();
    public List<Transform> remainingParts = new List<Transform>();
    [SerializeField] private float explosiveForce = 1;
    [SerializeField] private float explosiveRadius = 2;
    private void Start()
    {
        foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        {
            contactedParts.Add(t);
        }
    }
    public void Seperate()
    {
        transform.DetachChildren();
        StartCoroutine(DetachParts());
        foreach (Transform child in contactedParts)
        {
            if (!child.CompareTag("Debree"))
            {
                child.parent = null;
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, Vector3.up, explosiveRadius);               
                //child.GetComponent<Collider>().enabled = false;
                child.tag = "Debree";            
            }
        }
        foreach (Transform child in remainingParts)
        {               
                child.parent = null;
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, Vector3.up, explosiveRadius);
                //child.GetComponent<Collider>().enabled = false;
                child.tag = "Debree";              
        }
    }
    
    IEnumerator DetachParts()
    {
        yield return new WaitForSeconds(.2f);
        foreach(Transform obj in contactedParts)
        {
            obj.DetachChildren();
        }
        foreach (Transform obj2 in remainingParts)
        {
            obj2.DetachChildren();
        }
    }
}

