using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour {
    [SerializeField] int scorePerHit = 12;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform Parent;
    [SerializeField] int hits = 3;
    ScoreBoard scoreboard;
	// Use this for initialization
	void Start () {
        
        scoreboard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();

	}

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProccessHit();
        if (hits <= 1)
        {
            Killenemy();
        }


    }

    private void ProccessHit()
    {
        scoreboard.ScoreHit(scorePerHit);
        hits = hits - 1;
    }

    private void Killenemy()
    {
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = Parent;
        // Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
