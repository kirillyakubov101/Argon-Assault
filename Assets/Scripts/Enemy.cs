using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int scoreHit = 12;
	[SerializeField] GameObject DeathVFXPrefab;
	[SerializeField] Transform Parent;

	ScoreBoard scoreBoard;

	// Start is called before the first frame update
	void Start()
	{
		scoreBoard = FindObjectOfType<ScoreBoard>();
		AddANonTriggerBoxCollider();
	}

	private void AddANonTriggerBoxCollider()
	{
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		HandleHit();
	}

	private void HandleHit()
	{
		scoreBoard.ScoreHit(scoreHit); //Hit ship and get points
		GameObject explosion = Instantiate(DeathVFXPrefab, transform.position, Quaternion.identity);
		explosion.transform.parent = Parent;
		Destroy(explosion, 5f);
		Destroy(gameObject);
	}

}
