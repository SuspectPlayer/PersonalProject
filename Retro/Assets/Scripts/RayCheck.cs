using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    RaycastHit hit;
    public MoveEnemy move;
    // Start is called before the first frame update
   
    void Start()
    {
       
            move = transform.parent.GetComponent<MoveEnemy>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform != null && move.transform != null)
        {

            // Raycast to ground
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {

                if (hit.transform.CompareTag("Wall"))
                {
                    
                        move.GotoNextPoint();
                   
                    
                }
                Debug.DrawRay(transform.position, Vector3.down * 100, Color.red);
                
            }
        }
        

           
          
    }
}
