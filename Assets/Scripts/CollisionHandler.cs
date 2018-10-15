using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	
    private void OnTriggerEnter(Collider other)
    {
        print("you just hit something");
        SendMessage("OnPlayerDeath");

    }

}
