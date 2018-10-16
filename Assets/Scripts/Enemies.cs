using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
   
    [SerializeField] GameObject deathExplosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject other)
    {
        print("particle collided with enemy " + gameObject.name);
        Destroy(gameObject);
        print("exploded");
        deathExplosion.SetActive(true);
    }
}
