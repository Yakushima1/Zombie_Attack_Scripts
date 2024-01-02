using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour
{
    public GameObject BulletCasingPrefab;
    public float speed;

    public void BulletCasing()
    {
        GameObject go = Instantiate(BulletCasingPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
