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
	
	[SerializeField] AudioClip[] launch;
	[SerializeField] AudioClip[] sfxexplosions;
	
	AudioSource audioPlayer;
	Renderer someObject;


	// if a bullet is spawned, it either hits another object or it expires
	void Awake() {
	  startTime = Time.time;
	}
	
    // Start is called before the first frame update
    void Start() {
		// prime the audio object
		GameObject sfxobj = GameObject.Find("audioHolder");
		audioPlayer = sfxobj.GetComponent<AudioSource>();

		// when bullet is created, play the launch sound
		AudioClip clip = launch[Random.Range(0, launch.Length)];
		audioPlayer.PlayOneShot(clip, 0.05f);
		
		// fetch scores object, if we need to update scores we use scoreGO
		someObject = GetComponent<Renderer>();
		GameObject scoreGO = GameObject.Find("ScoresText");
		if (scoreGO != null) {
			scoreCounter = scoreGO.GetComponent<Scores>();
		}
    }
	
	public void Explode() {
		
		var randomNumber = Random.Range (0, 3);
		// pick one of three explosions to spawn
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
		
		// pick one of three explosion sounds to play
		if (isOnScreen(gameObject)) { 
			AudioClip clip = sfxexplosions[Random.Range(0, sfxexplosions.Length)];
			audioPlayer.PlayOneShot(clip);
		}
		// kill the bullet game object
		Destroy(gameObject);
		
	}
	
	
	// when we collide with an object, we must explode the bullet, if we collide with a plane, we need to increment the score and restart the scene
	void OnCollisionEnter(Collision coll) {
		if (isOnScreen(gameObject)) {
			GameObject collidedWith = coll.gameObject;
					Debug.Log("bullet hit " + coll.gameObject.name);
					Destroy(coll.gameObject);
					
					if (coll.gameObject.name == "MAIN2") {
						Debug.Log("point to p2 (black)");
						scoreCounter.MAINscore += 1;
						scoreCounter.DelayRestart();
					} else if (coll.gameObject.name == "MAIN") {
						Debug.Log("point to p1 (white)");
						scoreCounter.MAIN2score += 1;
						scoreCounter.DelayRestart();
					}
					
					Explode();
					//scoreCounter.DelayRestart();
					
		} else {
			
			//Debug.Log("not on screen");
			Destroy(gameObject);
		}
	}
	
	// check if the object is on screen
	bool isOnScreen(GameObject obj) {
		
		Frustum f = Camera.main.GetFrustum();
		if (f.TestBounds(someObject.bounds) != EFrustumIntersection.Outside) {
			return true;
		} else {
			return false;
		}

	}
	
	

    // Update is called once per frame
    void Update()
    {
		// after the bullet is spawned, it travels in the direction it was fired
		transform.position += transform.up * Time.deltaTime * bulletSpeed;
		
		transform.rotation *= Quaternion.Euler (0f, 2f, 0f);
		// will expire after 1.4f
		if ((Time.time - startTime) > 1.4f) {
			Explode();
		}
        
    }
}
