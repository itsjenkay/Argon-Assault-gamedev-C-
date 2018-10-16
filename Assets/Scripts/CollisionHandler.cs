using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
  [Tooltip("In second")]  [SerializeField] float LoadLevelDelay = 1f;
  [Tooltip("Explosion Effect")] [SerializeField] GameObject DeathFX;
   
    private void OnTriggerEnter(Collider collision)
    {
      SendMessage("OnPlayerDeath");
      DeathFX.SetActive(true);
      Invoke("RestartLevel", LoadLevelDelay);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
  
}
