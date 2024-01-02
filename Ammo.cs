using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        StartCoroutine(destroyDelayed());
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform.rotation = player.rotation;
    }

    IEnumerator destroyDelayed()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
