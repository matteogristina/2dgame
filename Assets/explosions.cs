using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explosions : MonoBehaviour
{
	float startTime;
	
    // Start is called before the first frame update
    void Start()
    {
		startTime = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > 1.8f) {
			Destroy(gameObject);
		}
    }
}