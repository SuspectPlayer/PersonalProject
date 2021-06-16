using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("Untagged"))
        {
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("Debrees"))
        {
            Destroy(other.gameObject);
        }
    }
}
