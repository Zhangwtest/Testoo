using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float destroyTime;

    void Start()
    {
       DestroySelf();
    }

    void DestroySelf()
    {
        StartCoroutine(WaitDestroy());
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }


}
