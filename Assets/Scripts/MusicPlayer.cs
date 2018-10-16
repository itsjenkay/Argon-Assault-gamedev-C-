using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
       int numberOfmusic = FindObjectsOfType<MusicPlayer>().Length;
        if (numberOfmusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
	// Use this for initialization
	
}
