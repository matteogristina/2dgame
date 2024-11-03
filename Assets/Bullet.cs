using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	public Scores scoreCounter;
	
	float startTime;
	float bulletSpeed = 28f;
	
	public GameObject exp1;
	public GameObject exp2;
	public GameObject exp3;
	
	Renderer someObject;

	void Awake() {
	  startTime = Time.time;
	}
	
    // Start is called before the first frame update
    void Start() {
		someObject = GetComponent<Renderer>();
		GameObject scoreGO = GameObject.Find("ScoresText");
		scoreCounter = scoreGO.GetComponent<Scores>();
    }
	
	public void Explode() {
		
		var randomNumber = Random.Range (0, 3);

		switch(randomNumber) {
		  case 0:
			Instantiate(exp1, transform.position, transform.rotation);
			break;

		  case 1:
			Instantiate(exp2, transform.position, transform.rotation);
			break;

		  case 2:
			Instantiate(exp3, transform.position, transform.rotation);
			break;

		}
		Destroy(gameObject);
		
	}
	
	void OnCollisionEnter(Collision coll) {
		if (isOnScreen(gameObject)) {
			GameObject collidedWith = coll.gameObject;
					Debug.Log("bullet hit " + coll.gameObject.name);
					Destroy(coll.gameObject);
					
					if (coll.gameObject.name == "MAIN2") {
						Debug.Log("point to p2 (black)");
						scoreCounter.MAINscore += 1;
					} else {
						Debug.Log("point to p1 (white)");
						scoreCounter.MAIN2score += 1;
					}
					
					Explode();
					scoreCounter.DelayRestart();
					
		} else {
			
			//Debug.Log("not on screen");
			Destroy(gameObject);
		}
	}
	
	
	bool isOnScreen(GameObject obj) {
		
		Frustum f = Camera.main.GetFrustum();
		if (f.TestBounds(someObject.bounds) == EFrustumIntersection.Inside) {
			return true;
		} else {
			return false;
		}

	}
	
	

    // Update is called once per frame
    void Update()
    {
		
		transform.position += transform.up * Time.deltaTime * bulletSpeed;
		
		transform.rotation *= Quaternion.Euler (0f, 2f, 0f);
		
		if ((Time.time - startTime) > 1.4f) {
			Explode();
		}
        
    }
}
