using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPosition1 : MonoBehaviour
{
    bool foundPosition;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!foundPosition)
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * 100 * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        foundPosition = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.isKinematic = true;
        foundPosition = true;
    }
}
