﻿using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Bullet Bullet;
    public float FireRate = 1.0f;
    public Light MuzzleFlash;

    private float lastFiredTimestamp;
	//private PlayerMovement playerMovement;
	private AudioSource laserSounds;

	private bool isShooting = false;

    void Start()
	{
		//playerMovement = GetComponent<PlayerMovement> ();
		laserSounds = GetComponent<AudioSource> ();
        lastFiredTimestamp = Time.time;
    }

    void Update()
    {
		isShooting = Input.GetButton ("Fire");
        if (Input.GetButton("Fire") && Time.time - lastFiredTimestamp >= FireRate)
        {
            Shoot();
            if (MuzzleFlash != null)
            {
				laserSounds.Play ();
				//playerMovement.MovementSpeed = 0.3f;
                MuzzleFlash.enabled = true;
            }
        }
        else
        {
			

            if (MuzzleFlash != null)
            {
				//playerMovement.MovementSpeed = 2.2f;
                MuzzleFlash.enabled = false;
            }
        }
    }

    void Shoot()
    {
        var bullet = Bullet.GetPooledInstance<Bullet>();
        bullet.Initialize(transform.position, transform.rotation);
        lastFiredTimestamp = Time.time;
    }

	public bool IsShooting(){
		return isShooting;
	}

}