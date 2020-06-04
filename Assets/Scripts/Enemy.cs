using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
		AddANonTriggerBoxCollider();
    }

	private void AddANonTriggerBoxCollider()
	{
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		Destroy(gameObject);
	}
}
