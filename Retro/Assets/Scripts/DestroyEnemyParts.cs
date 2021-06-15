using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyParts : MonoBehaviour
{
    public List<Transform> unparentedPartsList = new List<Transform>();

    private void Update()
    {
        if (unparentedPartsList.Count > 0)
        {
            DestroyParts();
        }
    }
    void DestroyParts()
    {
        for (int i = 0; i < unparentedPartsList.Count; i++)
        {
            StartCoroutine(DestorySlowly(unparentedPartsList[i], 3));
        }
    }
    IEnumerator DestorySlowly(Transform t, float time)
    {
        if (t != null)
        {
            unparentedPartsList.Remove(t);
            yield return new WaitForSeconds(time);
            if (t != null)
            {
                Destroy(t.gameObject);
            }
        }
    }
}
