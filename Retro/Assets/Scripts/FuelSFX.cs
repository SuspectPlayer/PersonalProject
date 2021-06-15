using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSFX : MonoBehaviour
{
    private int triggerCount = 0;
    public AudioSource source;

   

   
    void OnTriggerEnter(Collider collider)
    {
        source = gameObject.GetComponent<AudioSource>();

        if (source != null)
        {
            source.Play();
            
            triggerCount++;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        source = gameObject.GetComponent<AudioSource>();
        
        if (source != null)
        {
            triggerCount--;
            if (triggerCount <= 0)
            {

                Destroy(source);
            }
        }
    }
}
