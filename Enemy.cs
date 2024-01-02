using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    
    public float health = 100;

    private Animator anim;
	
    public bool isDead = false;

	public GameObject healthModel;

	public GameObject magModel;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void damage(float amount)
    {
        health -= amount;
        if(health <= 0 && !isDead)
        {
            onDeath();
        }
    }

    public void onDeath()
    {
        anim.SetBool("isDead", true);
        isDead = true;
        gameObject.tag = "Untagged";
        player.points++;

		int item = Random.Range(1, 5);
		if(item == 1){
			DropHealth();
		}
		else if (item == 2)
		{
			DropMag();
		}
        StartCoroutine(deleteEnemy());	
    }

    IEnumerator deleteEnemy()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }

	void DropHealth(){
		Vector3 position = gameObject.transform.position;
		position.y = position.y + 1;
		GameObject health = Instantiate(healthModel, position, Quaternion.identity); 		
	}

	void DropMag(){
		Vector3 position = gameObject.transform.position;
		position.y = position.y + 1;
		GameObject mag = Instantiate(magModel, position, Quaternion.identity); 		
	}

}
