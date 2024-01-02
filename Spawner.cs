using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public Player player;

    private float time;

    private int spawnedAmount = 0;
    
    void Start()
    {
        StartCoroutine(timer());
        
    }

    public void Create()
    {
        GameObject go = Instantiate(zombie, transform.position, Quaternion.identity);
        go.GetComponent<Enemy>().player = player;
    }


    IEnumerator timer()
    {
        time = Random.Range(3, 9 - Math.Min(spawnedAmount / 3, 4));
        spawnedAmount++;
        yield return new WaitForSeconds(time);
        Create();
        StartCoroutine(timer());
    }
    
}