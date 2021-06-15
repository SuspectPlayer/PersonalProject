using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerBullet : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullet;
    MovePlayer player;
    public float fireRate = 0.2f;

    bool canFire;
    private void Start()
    {
        player = FindObjectOfType<MovePlayer>();
        canFire = true;
    }
    void Update()
    {
        if (!player.freeze)
        {
            if (Input.GetMouseButton(0) && canFire)
            {
                
                StartCoroutine(FireBullet());
            }
        }
    }
    IEnumerator FireBullet()
    {
        GameObject shot = Instantiate(bullet, muzzle);
        shot.transform.parent = null;
        canFire = false;

        yield return new WaitForSeconds(fireRate);
        canFire = true;

    }
}
