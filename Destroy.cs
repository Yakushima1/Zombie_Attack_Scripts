using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroyAfterDelay());
    }
    
    IEnumerator destroyAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
