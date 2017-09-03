﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	private const string PLAYER_TAG = "Player";
	public int healthAmount = 50;

	public AudioClip healthSpawnSFX;
	public AudioClip healthCollectedSFX;

	private AudioSource audioSource;
	public GameObject model;
	public GameObject pickupLight;
	private bool isCollected = true;

	public void Start(){
		audioSource = GetComponent<AudioSource> ();
		SetVisability (false);
	}

	public void SpawnHealthPickup(Vector3 position){
		transform.position = position;
		if (audioSource != null && healthSpawnSFX != null) {
			audioSource.PlayOneShot (healthSpawnSFX);
		}
		SetVisability(true);
		isCollected = false;
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag (PLAYER_TAG) && !isCollected) {
			BaseHealth playerHealth = other.gameObject.GetComponentInParent<BaseHealth> ();

			if (playerHealth != null) {
				playerHealth.Heal (healthAmount);
				isCollected = true;

				if (audioSource != null && healthCollectedSFX != null) {
					audioSource.PlayOneShot (healthCollectedSFX);
				}

				SetVisability (false);
			}
		}
	}

	private void SetVisability(bool active){
		model.SetActive (active);
		pickupLight.SetActive (active);
	}

	public bool IsCollected(){
		return isCollected;
	}
}