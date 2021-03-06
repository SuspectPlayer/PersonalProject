using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuel : MonoBehaviour
{
    StatsCounter stats;
    void Start()
    {
        stats = FindObjectOfType<StatsCounter>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            stats.fuelSpeed = +5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            stats.fuelSpeed = -1;
        }
    }
}
