using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform Parent;
	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject FX=  Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = Parent;
       // Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    
       
    }
}
