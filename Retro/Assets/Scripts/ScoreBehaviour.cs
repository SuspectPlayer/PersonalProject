using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    new Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        //transform.GetComponent<Rigidbody>().AddExplosionForce(forceAmount,Vector3.up, 1);
        transform.LookAt(camera);
        transform.rotation = Quaternion.LookRotation(transform.position - camera.position);
        StartCoroutine(DestroyText());
    }

   public IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
