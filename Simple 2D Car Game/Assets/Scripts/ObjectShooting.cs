using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooting : MonoBehaviour
{
    [SerializeField] float shotCounter;

    [SerializeField] float health = 1f;

    [SerializeField] float minTimeBetweenShots = 0.5f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject objectLaserPrefab;

    [SerializeField] float objectLaserSpeed = 0.3f;

    [SerializeField] AudioClip objectDeathSound;
    [SerializeField] [Range(0, 1)] float objectDeathSoundVolume = 0.75f;

    [SerializeField] bool shoot;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;




    void Start()
    {
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }

    private void Update()
        {
            CountDownAndShoot();
        }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            ObjectFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        }
    }

    private void ObjectFire()
    {
        if (shoot == true)
        {
            GameObject objectLaser = Instantiate(objectLaserPrefab, transform.position, Quaternion.identity) as GameObject;

            objectLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -objectLaserSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        if(dmgDealer != null)
        {
            ProccessHit(dmgDealer);
        }
    }

    private void ProccessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);
    }

}