using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
  [Tooltip ("in ms^-1 ")]  [SerializeField] float Speed = 20f;
  [Tooltip ("in m ")]  [SerializeField] float xRange = 5.5f;
  [Tooltip ("in m ")]  [SerializeField] float yRange = 2.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

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
    }
}
