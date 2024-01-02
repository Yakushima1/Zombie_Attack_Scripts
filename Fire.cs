using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fire : MonoBehaviour
{
    public float distance;

    public GameObject weapon;

    public float fireRate;
    float timer;

    public float damage;

    public float AimAssist;

    public int ammoCount;
    public int mag;
    public int magAmmo;

    public TextMeshProUGUI ammoCountText, magText;

    public Image crosshair;

    bool fire = true;
    bool scope = false;

    public AudioSource sfx;
    public AudioClip ak;
    public AudioClip reload;
    public AudioClip empty;

    public ParticleSystem muzzleflash;

    public Animation animations;

    public Vector3 NormalP;
    public Vector3 AimP;

    private void Start()
    {
        ammoCountText.text = ammoCount.ToString();
        magText.text = mag.ToString();
    }

    void FixedUpdate()
    {
        if (fire == true && Time.time > timer && (Input.GetMouseButton(0)))
        {
            if (ammoCount > 0)
            {
                Fire();
                timer = Time.time + fireRate;
            }
            else if (mag > 0 && ammoCount < 30)
            {
                Reload();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (ammoCount <= 0 && mag <= 0)
            {
                sfx.clip = empty;
                sfx.Play();
            }
        }

        if(Input.GetMouseButton(1))
        {
            weapon.GetComponent<Delayeffect>().enabled = false;
            weapon.transform.localPosition = Vector3.Slerp(weapon.transform.localPosition, AimP, 8f * Time.deltaTime);
            scope = true;
            crosshair.enabled = false;
        }
        else
        {
            weapon.GetComponent<Delayeffect>().enabled =true;
            scope = false;
            crosshair.enabled = true;
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (mag > 0 && ammoCount < 30)
            {
                Reload();
            }
        }

        crosshair.color = Color.white;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.distance <= distance && hit.collider.gameObject.tag == "Enemy")
                crosshair.color = Color.red;
        }
    }

    public void Fire()
    {
        muzzleflash.Play();

        sfx.clip = ak;
        sfx.Play();

        ammoCount--;
        ammoCountText.text = ammoCount.ToString();

        if(scope == false)
        {
            animations.Play("fire");
        }
        else
            animations.Play("scopeFire");

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, AimAssist, transform.forward, out hit))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.damage(damage);
            }
        }
    }

    public void Reload()
    {
        mag--;
        ammoCount = magAmmo;
        ammoCountText.text = ammoCount.ToString();
        magText.text = mag.ToString();
        animations.Play("Reload");
        fire = false;
        StartCoroutine(changeMag());
    }

	public void incrementAmmo() 
	{
		mag++;
        magText.text = mag.ToString();
	}

    IEnumerator changeMag()
    {
        yield return new WaitForSeconds(0.5f);
        sfx.clip = reload;
        sfx.Play();
        yield return new WaitForSeconds(1f);
        sfx.clip = reload;
        sfx.Play();
        yield return new WaitForSeconds(0.50f);
        sfx.clip = reload;
        sfx.Play();
        yield return new WaitForSeconds(1f);
        fire = true;
    }

    public void yenile()
    {
        ammoCountText.text = ammoCount.ToString();
        magText.text = mag.ToString();
    }
}

