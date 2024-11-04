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