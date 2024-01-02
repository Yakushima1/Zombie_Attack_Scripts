using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Zombie : MonoBehaviour
{
    private Transform target;

    private Player player;

    public AudioSource sfx;
    public AudioClip attack;
    NavMeshAgent agent;

    Animator anim;

    public Enemy enemy;

    public int damage;

    bool isAttacking = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (enemy.isDead == false && isAttacking == false)
        {
            anim.SetFloat("speed", agent.velocity.magnitude);

            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= 100)
            {
                agent.enabled = true;
                agent.destination = target.position;
            }
            else
            {
                agent.enabled = false;
            }
            if (distance <= 1.2)
            {
                agent.enabled = false;
            }
            if (enemy.isDead == true)
            {
                agent.enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isAttacking && other.gameObject.tag == "Player")
        {
            if (enemy.isDead == false)
            {
                anim.SetBool("isAttacking", true);
                isAttacking = true;
                StartCoroutine(attack());
            }
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        sfx.clip = attack;
        sfx.Play();
        player.damage(damage);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

}