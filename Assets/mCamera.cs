using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCamera : MonoBehaviour
{
	
	private static mCamera instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Awake()
    {
		// do not destroy the main camera on load, moves it so that the canvas can be attached the the camera at all times
        DontDestroyOnLoad(this);
		
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
