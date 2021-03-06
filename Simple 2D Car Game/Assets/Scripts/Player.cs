﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 7f;
    [SerializeField] int Health = 50;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    float xMin, xMax, yMin, yMax;
    float padding = 0.5f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmgDealer);

    }

    public int GetHealth()
    {
        return Health;
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        Health -= dmgDealer.GetDamage();
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    //setup the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding; //xMin = 0 according to the camera
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding; //xMax = 1 according to the camera




    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos = current x-pos of Player
        //+ difference in X by keyboard Input
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //update the position of the Player
        this.transform.position = new Vector2(newXPos, -3);

    }
    private void Die()
    {
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        FindObjectOfType<Level>().LoadGameOver();

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);

    }

}
