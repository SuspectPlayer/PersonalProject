using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float bulletSpeed = 100;
    public float lifeTime = 1;
    private void Start()
    {
       StartCoroutine(DestroySelf());
    }
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
