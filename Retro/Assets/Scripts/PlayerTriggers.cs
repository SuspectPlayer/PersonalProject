using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerTriggers : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerExit.Invoke();
        }
    }
}
