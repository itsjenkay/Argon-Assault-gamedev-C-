using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player: MonoBehaviour {
  [Header("General-Control")]
  [Tooltip ("in ms^-1 ")][SerializeField] float Speed = 20f;
  [Tooltip ("in m ")]  [SerializeField] float xRange = 5.5f;
  [Tooltip ("in m ")]  [SerializeField] float yRange = 2.5f;
    [SerializeField] GameObject[] guns;
  [Header("Screen Position-Controller")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

 [Header("Screen Control-Controller")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -21.56f;

    
    float yThrow;
    float xThrow;
    bool isControlEnable = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnable == true)
        {
            ProcessTranslation();
            processRotation();
            ProccessFiring();
        }
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        isControlEnable = false;
    
    }
    
   void OnPlayerDeath()
    {
       
    }
   
   
    private void processRotation()
    {
        float pitchDueToPosoition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch=pitchDueToControl + pitchDueToPosoition;
        float yaw=transform.localPosition.x*positionYawFactor;
        float roll=xThrow*controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        print("Rotating very good");

    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float xRawPos = transform.localPosition.x + xOffset;
        float yRawpos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(yRawpos, -yRange, yRange);

        transform.localPosition = new Vector3
            (
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
            );
        print("working fine");
    }

    void ProccessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            setGunsActive(true);
        }
        else
        {

            setGunsActive(false);

        }
    }
    private void setGunsActive( bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
    
    
}
