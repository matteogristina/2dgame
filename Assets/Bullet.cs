using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	float startTime;
	float bulletSpeed = 28f;

	void Awake() {
	  startTime = Time.time;
	}
	
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		transform.position -= transform.right * Time.deltaTime * bulletSpeed;
		
		if ((Time.time - startTime) > 1.4f) {
			Destroy(gameObject);
		}
        
    }
}
